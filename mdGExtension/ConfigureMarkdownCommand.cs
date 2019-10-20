using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Threading;
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
        }

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
            _DoWorkAsync();
        }

        private async Task _DoWorkAsync()
        {
            string targetName = "mdGTask";
            string docFile = "DocumentationFile";

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            DTE s = await (ServiceProvider as AsyncPackage).GetServiceAsync(typeof(SDTE)) as DTE ?? null;

            Array projs = s.ActiveSolutionProjects as Array;
            Project proj = projs.GetValue(0) as Project;

            string fileName = proj.FileName;
            XDocument xDoc = XDocument.Load(fileName);
            XElement xEl = xDoc.Root;

            XElement extTarget = xEl.Elements()
                .Where(x => x.Name.LocalName == "Target")
                .Where(x => x.Attribute("Name").Value == targetName)
                .FirstOrDefault();
            XElement xmlProp = xEl.Elements()
                .Where(x => x.Name.LocalName == "PropertyGroup")
                .Elements()
                .Where(x => x.Name.LocalName == docFile)
                .FirstOrDefault();

            DataEntryForm form = new DataEntryForm();
            form.XMLPath.Text = xmlProp?.Value;
            form.OutputPath.Text = extTarget.Descendants().Where(x => x.Name.LocalName == "mDOutput").FirstOrDefault().Value;
            form.GenerateMarkdown.IsChecked = extTarget != null;
            form.ProjDir = Path.GetDirectoryName(fileName);

            form.ShowDialog();

            if (form.GenerateMarkdown.IsChecked ?? false)
            {
                //using namespace because argh!
                string ns = xEl.Name.NamespaceName;

                //set xml documentation output folder if not already specified in proj file
                if (string.IsNullOrWhiteSpace(xmlProp?.Value))
                {
                    if (xmlProp == null)
                        xEl.Elements()
                            .Where(x => x.Name.LocalName == "PropertyGroup")
                            .FirstOrDefault()
                            .Add(new XElement($"{{{ns}}}{docFile}", Path.Combine("bin\\Debug", $"{proj.Name}.xml")));
                    else
                        xmlProp.Value = Path.Combine("bin\\Debug", $"{proj.Name}.xml");
                }

                //if the target is not already in the proj file, then add
                if (extTarget == null)
                {
                    XElement outX = new XElement($"{{{ns}}}mDOutput", form.OutputPath.Text);
                    XElement cmdX = new XElement($"{{{ns}}}mdGExecute", "Vsxmd \"$(DocumentationFile)\" \"$(mDOutput)\"");
                    XElement propGroup = new XElement($"{{{ns}}}PropertyGroup", outX, cmdX);

                    XElement execX = new XElement($"{{{ns}}}Exec", new XAttribute("Command", "$(mdGExecute)"));

                    XElement tElement = new XElement($"{{{ns}}}Target", propGroup, execX);
                    tElement.Add(new XAttribute("Name", targetName));
                    tElement.Add(new XAttribute("AfterTargets", "PostBuildEvent"));

                    xEl.Add(tElement);
                }
                else
                    extTarget.Descendants().Where(x => x.Name.LocalName == "mDOutput").FirstOrDefault().Value = form.OutputPath.Text;
            }
            //If user doesn't want md, just remove our target node
            else if (extTarget != null)
                extTarget.Remove();

            xDoc.Save(proj.FileName);
        }

    }

}
