using System;

namespace MTALuaCompiler
{
    static class ConsoleHelper
    {
        public static void WriteErrorLine(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteSuccessLine(string text)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteSufixLine(string sufix, string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(sufix);
            Console.ResetColor();
            Console.WriteLine("  "+text);
        }
    }
}
