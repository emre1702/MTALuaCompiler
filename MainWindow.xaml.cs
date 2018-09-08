using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MTALuaCompiler
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UploadFileButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog(this.GetIWin32Window());
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    FolderPathBox.Text = dialog.SelectedPath;
                }
                
            }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string path = FolderPathBox.Text;
            if (!Directory.Exists(path))
            {
                ConsoleHelper.WriteErrorLine("Path doesn't exist!");
                MessageBoxHelper.ShowError("Path doesn't exist!");
            }
            ((Button)sender).IsEnabled = false;
            await Task.Run(() => this.StartCompile(path));
            ((Button)sender).IsEnabled = true;
        }
    }
}
