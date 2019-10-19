using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace mdGInstallerActions
{
    [RunInstaller(true)]
    public partial class InstallerActions : Installer
    {
        public InstallerActions()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string pathVars = Environment.GetEnvironmentVariable("PATH");
            string installDir = Context.Parameters["path"].TrimEnd('\\');
            string separator = Path.DirectorySeparatorChar.ToString();
            installDir += installDir.EndsWith(separator, StringComparison.OrdinalIgnoreCase) ? separator : "";

            if (!pathVars.Contains(installDir))
                Environment.SetEnvironmentVariable("PATH", $"{pathVars};{installDir}", EnvironmentVariableTarget.Machine);

            MessageBox.Show(installDir);
            MessageBox.Show(pathVars);

            if (File.Exists(Path.Combine(installDir, "mdGExtension.vsix")))
                Process.Start(Path.Combine(installDir, "mdGExtension.vsix"));

        }

    }

}
