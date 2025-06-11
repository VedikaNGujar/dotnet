using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased.GitHubOutputBased
{
    
    internal class _4File
    {
        record Point(int X, int Y);
        public static void Main()
        {
            object shape = new Point(3, 4);
            Console.WriteLine(GetSum(shape));
        }
        static int GetSum(object obj)
        {
            return obj switch
            {
                Point(var x, var y) => x + y,
                _ => 0
            };
        }
    }
}
