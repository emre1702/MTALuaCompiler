﻿using System.Threading.Tasks;
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            string path = FolderPathBox.Text;
            Task.Run(() => this.StartCompile(path)).Wait();
            ((Button)sender).IsEnabled = true;
        }
    }
}