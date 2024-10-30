using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{
    internal static class Restriction
    {
        //where
        public static void Test()
        {
            Console.WriteLine("---Restriction---");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            IEnumerable<int> result;
            result = numbers.Where(x => x % 2 == 0);
            Console.WriteLine("Print even numbers : ");
            result.ToList().ForEach(x => Console.WriteLine(x));

            result = numbers.Where((x, y) => y % 2 == 0);
            Console.WriteLine("Print numbers at even indexes : ");
            result.ToList().ForEach(x => Console.WriteLine(x));

            IEnumerable<string> colourResult;
            string[] colour = { "Blue", "Red", "Green", "Yellow", "Black", "Brown", "Pink", "Grey" };
            colourResult = colour.Where((x, y) => x.StartsWith("B") && y % 2 == 0);
            Console.WriteLine("Colors which starts with B and whose index is even : ");
            colourResult.ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
