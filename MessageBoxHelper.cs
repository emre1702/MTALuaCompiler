using System.ComponentModel;
using System.Windows;

namespace MTALuaCompiler
{
    static class MessageBoxHelper
    {

        private static readonly BackgroundWorker worker = new BackgroundWorker();

        public static void ShowError(string text)
        {
            worker.DoWork += ((object sender, DoWorkEventArgs e) => MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error));
            worker.RunWorkerAsync();
        }

    }
}
