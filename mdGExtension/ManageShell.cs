using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using Task = System.Threading.Tasks.Task;
using Vsxmd;

namespace mdGExtension
{
    internal static class ManageShell
    {
        private static DTE _DTE;

        private static readonly string docVar = "DocumentationFile";
        private static readonly string solnStore = "mDOutput";

        internal static async Task SetupAsync(AsyncPackage package, OleMenuCommandService commandService)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            _DTE = await (package as AsyncPackage).GetServiceAsync(typeof(SDTE)) as DTE ?? null;

            if (_DTE != null)
            {
                _DTE.Events.BuildEvents.OnBuildDone += _OnBuilt;
                Globals g = _DTE.Solution.Globals;
            }
        }

        static void _OnBuilt(vsBuildScope Scope, vsBuildAction Action)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            
            Solution soln = _DTE.Solution;
            Globals globals = soln.Globals;

            string[] exts = new string[] { ".csproj", ".vbproj" };
            List<Project> projs = soln.Projects.Cast<Project>()
                .Where(x => exts.Contains(Path.GetExtension(x.FileName), StringComparer.OrdinalIgnoreCase)).ToList();

            bool mDSet = globals.VariableExists[solnStore];
            string mDPath = mDSet ? globals[solnStore].ToString() : "";

            if (mDSet)
            {
                List<string> markdownPaths = new List<string>();

                foreach(Project proj in projs)
                {
                    XElement root = XDocument.Load(proj.FileName).Root;
                    XElement xmlProp = root.Elements()
                        .Where(x => x.Name.LocalName == "PropertyGroup")
                        .Elements()
                        .Where(x => x.Name.LocalName == docVar)
                        .FirstOrDefault();

                    if (xmlProp != null)
                        markdownPaths.Add(xmlProp.Value);
                }

                List<string> args = new List<string>() { mDPath };
                args.AddRange(markdownPaths);

                Vsxmd.Program.Main(args.ToArray());
            }

        }

        internal static void ConfigureSolution()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            
            Solution soln = _DTE.Solution;
            Globals globals = soln.Globals;

            string[] exts = new string[] { ".csproj", ".vbproj" };
            List<Project> projs = soln.Projects.Cast<Project>()
                .Where(x => exts.Contains(Path.GetExtension(x.FileName), StringComparer.OrdinalIgnoreCase)).ToList();

            bool mDSet = globals.VariableExists[solnStore];
            string mDPath = mDSet ? globals[solnStore].ToString() : "";

            DataEntryForm form = new DataEntryForm();
            form.OutputPath.Text = mDPath;
            form.GenerateMarkdown.IsChecked = mDSet;
            form.SolDir = Path.GetDirectoryName(soln.FileName);

            form.ShowDialog();

            if (form.GenerateMarkdown.IsChecked ?? false)
            {
                try
                {
                    Path.GetPathRoot(form.OutputPath.Text);
                }
                catch
                {
                    MessageBox.Show("Must use a valid path for Markdown output.");
                    return;
                }

                soln.Globals[solnStore] = form.OutputPath.Text;
                globals.VariablePersists[solnStore] = true;
                soln.SaveAs(soln.FileName);

                foreach (Project proj in projs)
                {
                    XElement root = XDocument.Load(proj.FileName).Root;
                    XElement xmlProp = root.Elements()
                        .Where(x => x.Name.LocalName == "PropertyGroup")
                        .Elements()
                        .Where(x => x.Name.LocalName == docVar)
                        .FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(xmlProp?.Value))
                    {

                        if (xmlProp == null)
                            root.Elements()
                                .Where(x => x.Name.LocalName == "PropertyGroup")
                                .FirstOrDefault()
                                .Add(new XElement($"{{{root.Name.Namespace}}}{docVar}", Path.Combine("bin\\Debug", $"{proj.Name}.xml")));
                        else
                            xmlProp.Value = Path.Combine("bin\\Debug", $"{proj.Name}.xml");

                        root.Document.Save(proj.FileName);
                    }
                }
            }
            //If user doesn't want md, just remove global from solution
            else if (mDSet)
            {
                globals[solnStore] = "";
                globals.VariablePersists[solnStore] = false;
                soln.SaveAs(soln.FileName);
            }

        }

    }

}
