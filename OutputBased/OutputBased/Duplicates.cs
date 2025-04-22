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
    }
}
