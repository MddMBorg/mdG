using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Threading;
using Vsxmd;
using XMLDocParser;
using Task = System.Threading.Tasks.Task;

namespace mdGExtension
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class ConfigureMarkdownCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("a260bbf7-d043-44f0-bfb2-a6f3ce8db41d");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage _Package;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureMarkdownCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private ConfigureMarkdownCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            _Package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static ConfigureMarkdownCommand Instance { get; private set; }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider => _Package;

        private DTE _DTE;
        private BuildEvents _Events;

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in ConfigureMarkdownCommand's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new ConfigureMarkdownCommand(package, commandService);

            Instance._DTE = await package.GetServiceAsync(typeof(SDTE)) as DTE ?? null;
            Instance._Events = Instance._DTE.Events.BuildEvents;

            ManageShell.DTE = Instance._DTE;

            if (Instance._DTE != null)
                Instance._Events.OnBuildDone += Instance._OnBuilt;
        }

        void _OnBuilt(vsBuildScope scope, vsBuildAction action)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            Solution soln = _DTE.Solution;
            Globals globals = soln.Globals;

            string[] exts = new string[] { ".csproj", ".vbproj" };
            //done as a foreach instead of linq to avoid thread safety warnings in lambdas
            List<Project> projs = new List<Project>();
            foreach (Project proj in soln.Projects)
            {
                var ext = Path.GetExtension(proj.FileName);
                if (exts.Contains(ext, StringComparer.OrdinalIgnoreCase))
                    projs.Add(proj);
            }

            bool mDSet = globals.VariableExists[ManageShell.solnStore];
            string mDPath = mDSet ? globals[ManageShell.solnStore].ToString() : "";
            Uri mdUri = new Uri(mDPath, UriKind.RelativeOrAbsolute);
            if (!mdUri.IsAbsoluteUri)
                mDPath = new Uri(new Uri(soln.FileName), mdUri).LocalPath;
            mDPath = mDPath + (mDPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString());

            if (mDSet)
            {
                //List<string> markdownPaths = new List<string>();
                DocManager docManager = new DocManager();

                foreach (Project proj in projs)
                {
                    XElement root = XDocument.Load(proj.FileName).Root;
                    XElement xmlProp = root.Elements()
                        .Where(x => x.Name.LocalName == "PropertyGroup")
                        .Elements()
                        .FirstOrDefault(x => x.Name.LocalName == ManageShell.docVar);

                    if (xmlProp == null)
                        continue;

                    //markdownPaths.Add(Path.Combine(Path.GetDirectoryName(proj.FileName), xmlProp.Value));

                    var doc = XDocument.Load(Path.Combine(Path.GetDirectoryName(proj.FileName), xmlProp.Value));
                    var members = docManager.GenerateMembers(doc);

                    var classes = GetItems(proj.ProjectItems).Where(x => x.Name.EndsWith(".cs")).ToList();

                    var types = classes.SelectMany(x => GetClasses(x)).ToList();
                    var props = GetProperties(types).ToList();
                    var methods = GetMethods(types).ToList();

                    foreach (var member in members.OfType<TypeMember>())
                    {
                        CodeType cT = types.FirstOrDefault(x => x.FullName == member.ID.TypeName);
                        if (cT == null)
                            continue;
                        
                        switch (cT.Kind)
                        {
                            case vsCMElement.vsCMElementClass:
                                member.ChangeClassType("Class");
                                break;
                            case vsCMElement.vsCMElementInterface:
                                member.ChangeClassType("Interface");
                                break;
                            case vsCMElement.vsCMElementEnum:
                                member.ChangeClassType("Enum");
                                break;
                            case vsCMElement.vsCMElementStruct:
                                member.ChangeClassType("Struct");
                                break;
                            case vsCMElement.vsCMElementDelegate:
                                member.ChangeClassType("Delegate");
                                break;
                        }

                        CodeInterface cI = cT as CodeInterface;
                        if (cI != null)
                        {
                            foreach (CodeInterface c in cI.Bases)
                                member.AddImplementor(c.FullName);
                            continue;
                        }

                        CodeClass cC = cT as CodeClass;
                        if (cC != null)
                        {
                            foreach (CodeElement c in cC.ImplementedInterfaces)
                                member.AddImplementor(c.FullName);
                            member.ChangeBaseClass(cC.Bases.Item(1).FullName);
                            continue;
                        }
                    }

                    new MarkdownWriter(doc, mDPath).WriteFiles();
                }

                //string[] args ={ string.Join(",", markdownPaths), mDPath + 
                //        (mDPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? "" : Path.DirectorySeparatorChar.ToString())};

                //Vsxmd.Program.Main(args);
            }
        }

        private IEnumerable<ProjectItem> GetItems(ProjectItems items)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (ProjectItem i in items)
            {
                yield return i;

                foreach (ProjectItem p in GetItems(i.SubProject?.ProjectItems ?? i.ProjectItems))
                    yield return p;
            }
        }

        #region GetClasses
        private IEnumerable<CodeType> GetClasses(ProjectItem item)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var codeModel = item.FileCodeModel;
            if (codeModel == null)
                yield break;

            foreach (CodeElement element in codeModel.CodeElements)
            {
                CodeNamespace nS = element as CodeNamespace;
                if (nS != null)
                    foreach (CodeType t in GetClasses(nS))
                        yield return t;

                CodeType type = element as CodeType;
                if (type != null)
                {
                    foreach (var t in GetClasses(type))
                        yield return t;

                    yield return type;
                }
            }
        }

        private IEnumerable<CodeType> GetClasses(CodeNamespace element)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (CodeElement member in element.Members)
            {
                CodeNamespace nS = member as CodeNamespace;
                if (nS != null)
                    foreach (CodeType t in GetClasses(nS))
                        yield return t;

                CodeType type = member as CodeType;
                if (type != null)
                {
                    foreach (var t in GetClasses(type))
                        yield return t;

                    yield return type;
                }
            }
        }

        private IEnumerable<CodeType> GetClasses(CodeType element)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (CodeElement member in element.Members)
            {
                CodeNamespace nS = member as CodeNamespace;
                if (nS != null)
                    foreach (CodeType t in GetClasses(nS))
                        yield return t;

                CodeType type = member as CodeType;
                if (type != null)
                {
                    foreach (var t in GetClasses(type))
                        yield return t;

                    yield return type;
                }
            }
        }
        #endregion

        #region GetProperties
        private IEnumerable<CodeProperty> GetProperties(IEnumerable<CodeType> types)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (CodeType type in types)
            {
                foreach (CodeElement member in type.Members)
                {
                    CodeProperty prop = member as CodeProperty;
                    if (prop != null)
                        yield return prop;
                }
            }
        }
        #endregion

        #region GetMethods
        private IEnumerable<CodeFunction> GetMethods(IEnumerable<CodeType> types)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            foreach (CodeType type in types)
            {
                foreach (CodeElement member in type.Members)
                {
                    CodeFunction method = member as CodeFunction;
                    if (method != null)
                        yield return method;
                }
            }
        }
        #endregion

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ManageShell.ConfigureSolution();
        }

    }

}
