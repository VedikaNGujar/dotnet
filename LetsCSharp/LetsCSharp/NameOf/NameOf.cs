using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.NameOf
{
    internal static class NameOf //get name of the variable
    {
        public static void Test()
        {


            dynamic obj = new { FirstName = "", LastName = "" };
            Console.WriteLine($"nameof {nameof(obj.FirstName)}");
            Console.WriteLine($"nameof {nameof(obj.LastName)}");


            Console.WriteLine($"nameof {nameof(Common.Subject.Title)}");

        }

    }
}
