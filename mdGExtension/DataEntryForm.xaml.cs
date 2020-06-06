using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace mdGExtension
{
    public partial class DataEntryForm : Window
    {
        private string _SolDir;
        public string SolDir
        {
            get => _SolDir;
            set => _SolDir = value + (value.EndsWith("\\") ? "" : "\\");
        }

        public DataEntryForm()
        {
            InitializeComponent();
        }

        void _SelectFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog picker = new FolderBrowserDialog
            {
                SelectedPath = SolDir
            };

            if (picker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dir = picker.SelectedPath;
                if (AbsoluteUri.IsChecked ?? false)
                {
                    Uri source = new Uri(SolDir);
                    Uri dest = new Uri(dir);
                    Uri diff = source.MakeRelativeUri(dest);
                    OutputPath.Text = diff.ToString().Replace('/', Path.DirectorySeparatorChar);
                }
                else
                    OutputPath.Text = dir;
            }
        }

        private void AbsoluteUri_Checked(object sender, RoutedEventArgs e)
        {
            var dir = OutputPath.Text;
            Uri source = new Uri(SolDir);
            Uri dest = new Uri(dir, UriKind.RelativeOrAbsolute);

            if (!dest.IsAbsoluteUri)
                OutputPath.Text = new Uri(source, dest).LocalPath;
        }

        private void AbsoluteUri_Unchecked(object sender, RoutedEventArgs e)
        {
            var dir = OutputPath.Text;
            Uri source = new Uri(SolDir);
            Uri dest = new Uri(dir, UriKind.RelativeOrAbsolute);

            if (dest.IsAbsoluteUri)
            {
                Uri diff = source.MakeRelativeUri(dest);
                OutputPath.Text = diff.ToString().Replace('/', Path.DirectorySeparatorChar);
            }
        }
    }

}
