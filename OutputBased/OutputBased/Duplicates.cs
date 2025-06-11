using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class Duplicates
    {
        public static void Approach1(int[] arr)
        {
            var duplicates = arr.GroupBy(x => x)
               .Where(x => x.Count() > 1)
               .Select(g => g.Key);

            foreach (var dup in duplicates)
            {
                Console.Write($" {dup} ");
            }
        }

        public static void Approach2(string str)
        {

            var dupli = str.GroupBy(x => x).Select(x => new { Chars = x.Key, Count = x.Count() }).ToList();

            foreach (var dup in dupli)
            {
                Console.WriteLine($"Chars : {dup.Chars}  Count : {dup.Count}");
            }
        }

        public static void Approach3()
        {
            int[] arr1 = new int[] { 7, 7, 8, 8, 9, 1, 1, 4, 2, 2 };

            arr1 = arr1.Distinct().ToArray();

            foreach (var num in arr1)
            {
                Console.WriteLine(num);
            }
        }
    }
}
