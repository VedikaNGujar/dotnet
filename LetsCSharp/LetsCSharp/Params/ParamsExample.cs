using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Params
{
    //Using params you can pass 0 or more arguments but with arrays you have to provide arguments if it is not optional
    internal class ParamsExample
    {
        public static int Add(params int[] listNumbers)
        {
            int total = 0;

            // foreach loop
            foreach (int i in listNumbers)
            {
                total += i;
            }

            return total;
        }

        public static int Add(int startValue, params int[] listNumbers)
        {
            int total = startValue;

            // foreach loop
            foreach (int i in listNumbers)
            {
                total += i;
            }

            return total;
        }


        public static string ConcatString(params string[] words)
        {
            return string.Join(" ", words);
        }
    }
}
