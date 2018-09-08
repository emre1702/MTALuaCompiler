using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace MTALuaCompiler
{
    static class LuaCompiler
    {

        private static void Compile(string filepath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                FileName = "luac_mta.exe",
                Arguments = $"-e2 -o {filepath}c {filepath}",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                Verb = "runas"
                
            };
            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    string output = exeProcess.StandardOutput.ReadToEnd();
                    if (output.Length != 0)
                    {
                        ConsoleHelper.WriteErrorLine(output);
                        MessageBoxHelper.ShowError(output);
                    } else
                    {
                        ConsoleHelper.WriteSuffixLine(Path.GetFileName(filepath), filepath);
                    }
                    exeProcess.WaitForExit();
                }
            } catch (Exception ex)
            {
                ConsoleHelper.WriteErrorLine(ex.Message);
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        public static void StartCompile(this Visual visual, string path)
        {
            foreach (string filepath in Directory.EnumerateFiles(path, "*.lua", SearchOption.AllDirectories).Where(file =>
                               Path.GetExtension(file) == ".lua"))
            {
                if (File.Exists(filepath+"c"))
                {
                    File.Delete(filepath + "c");
                }
                Compile(filepath);
            }
            ConsoleHelper.WriteSuccessLine("Done");
        }
    }
}
