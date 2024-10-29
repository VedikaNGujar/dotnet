using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.CloneAndCopy
{
    internal class CloneAndCopy
    {
        public void Test()
        {
            int[] arr = new int[3] { 1, 2, 3 };
            int[] arr2 = (int[])arr.Clone();

            int[] arr3 = new int[4] { 11, 12, 13, 14 };
            arr.CopyTo(arr3, 0);
        }
    }
}
