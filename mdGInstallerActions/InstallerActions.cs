using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
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

            string path = Environment.GetEnvironmentVariable("PATH");
            string installDir = Context.Parameters["path"].TrimEnd('\\');
            string separator = Path.DirectorySeparatorChar.ToString();
            installDir += installDir.EndsWith(separator, StringComparison.OrdinalIgnoreCase) ? separator : "";

            if (!path.Contains(installDir))
                Environment.SetEnvironmentVariable("PATH", $"{path};{installDir}", EnvironmentVariableTarget.Machine);

            MessageBox.Show(installDir);
            MessageBox.Show(path);


        }


    }

}
