using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{

    
    internal static class Aggregate
    {
        //min, max, sum, count, average
        public static void Test()
        {
            Console.WriteLine("---Aggregations---");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Console.WriteLine("Minimum : " + numbers.Min());
            Console.WriteLine("Maximum : " + numbers.Max());
            Console.WriteLine("Sum : " + numbers.Sum());
            Console.WriteLine("Sum of even : " + numbers.Where(x => x % 2 == 0).Sum());
            Console.WriteLine("Sum of odd : " + numbers.Where(x => x % 2 != 0).Sum());
            Console.WriteLine("Average : " + numbers.Average());

            string[] countryNames = { "India", "UK", "USA" };

            Console.WriteLine("Shortest Country Length " + countryNames.Min(x => x.Length));

            Console.WriteLine("Comma Seperate Countries Using Aggregate " + countryNames.Aggregate((a, b) => $"{a} , {b}"));
            Console.WriteLine("Multiplication of numbers Using Aggregate " + new[] { 1, 2, 3, 4, 5 }.Aggregate((a, b) => a * b));
            Console.WriteLine("Multiplication of numbers Using Aggregate with Seed " + new[] { 1, 2, 3, 4, 5 }.Aggregate(10, (a, b) => a * b));
        }
    }
}
