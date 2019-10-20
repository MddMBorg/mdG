using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;

namespace mdGExtension
{
    public partial class DataEntryForm : Window
    {
        public string ProjDir { get; set; }

        public DataEntryForm()
        {
            InitializeComponent();
        }

        void _SelectFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog picker = new FolderBrowserDialog();
            picker.SelectedPath = ProjDir;
            string dir = "";
            if (picker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dir = picker.SelectedPath;
                Uri source = new Uri(ProjDir + (!ProjDir.EndsWith("\\") ? "\\" : ""));
                Uri dest = new Uri(dir + (!dir.EndsWith("\\") ? "\\" : ""));
                Uri diff = source.MakeRelativeUri(dest);
                OutputPath.Text = diff.OriginalString;
            }
        }

    }

}
