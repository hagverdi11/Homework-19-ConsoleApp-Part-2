using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
    public static class Helper
    {
        public static void WriteConsole(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }

    public enum Menues
    {
        CreateLibrary = 1,
        GetLibraryById = 2,
        UpdateLibrary = 3,
        DeleteLibrary = 4,
        GetAllLibraries = 5,
        SearchLibrary = 6

    }
}
