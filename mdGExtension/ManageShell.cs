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
using EnvDTE80;

namespace mdGExtension
{
    internal static class ManageShell
    {
        internal static DTE DTE;
        
        internal static readonly string docVar = "DocumentationFile";
        internal static readonly string solnStore = "mDOutput";


        internal static void ConfigureSolution()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            
            Solution soln = DTE.Solution;
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
            form.AbsoluteUri.IsChecked = Path.IsPathRooted(form.SolDir);

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
                        .FirstOrDefault(x => x.Name.LocalName == docVar);

                    if (string.IsNullOrWhiteSpace(xmlProp?.Value))
                    {

                        if (xmlProp == null)
                            root.Elements()
                                .FirstOrDefault(x => x.Name.LocalName == "PropertyGroup")
                                .Add(new XElement(root.Name.Namespace + $"{docVar}", $"{proj.Name}.xml"));
                        else
                            xmlProp.Value = $"{proj.Name}.xml";

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
