using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Static
{
    public static class StaticExample
    {
        static StaticExample()
        {
            i = 10;
            Console.WriteLine($"Initialised Static {i} {j}");

        }
        //public int i = 0; //error, static class can contain only static members
        public static int i = 0;
        public static int j { get; set; }

        public static void GetName()
        {
            Console.WriteLine($"GetName Static {i} {j}");
        }
    }

    public class StaticExample2 : StaticExample //error cannot derive from Static
    {

    }
}
