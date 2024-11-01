using LetsCSharp.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{

    internal static class CastAndOfType
    {


        public static void Test()
        {
            Console.WriteLine("---Cast And OfType---");

            ArrayList arr = new ArrayList() { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine("------");
            Console.WriteLine("Cast");
            Console.WriteLine("------");
            var intArray = arr.Cast<int>();
            intArray.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("------");
            Console.WriteLine("Of Type");
            Console.WriteLine("------");
            intArray = arr.OfType<int>();
            intArray.ToList().ForEach(x => Console.WriteLine(x));


            Console.WriteLine("------");
            Console.WriteLine("Cast");
            Console.WriteLine("------");
            arr.AddRange(new ArrayList() { "anv", "bnbmn", 7, 8, 9 });
            //intArray = arr.Cast<int>(); // will throw error
            //intArray.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("------");
            Console.WriteLine("Of Type");
            Console.WriteLine("------");
            intArray = arr.OfType<int>(); // will exclude all the strings
            intArray.ToList().ForEach(x => Console.WriteLine(x));



        }
    }
}
