using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased.GitHubOutputBased
{
    internal static class _9File
    {
        public static void Main()
        {
            int x = 5;
            int y = 10;
            int result = Add(x, y);
            Console.WriteLine(result);

            static int Add(int a, int b)
            {
                return 1;
                //return a + b + x; //error for x
            }
        }
    }
}
