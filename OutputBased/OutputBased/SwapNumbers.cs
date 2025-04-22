using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class SwapNumbers
    {

        public static void Approach1(int num1, int num2)
        {
            Console.WriteLine($"nnum1 : {num1} num2 : {num2}");

            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;

            Console.WriteLine($"nnum1 : {num1} num2 : {num2}");
        }
    }
}
