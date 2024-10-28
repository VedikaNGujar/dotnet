using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    static class Helper
    {
        public static void WriteLine(string str)
        {
            Console.WriteLine($"{str}");
        }
        public static void WriteLineWithTab(string str)
        {
            Console.WriteLine($"\t {str}");
        }
    }
}
