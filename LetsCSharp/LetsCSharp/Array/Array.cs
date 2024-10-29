using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Array
{
    internal class Array
    {
        public void Test()
        {
            //SINGLE DIMENSIONAL ARRAY
            int[] arr = new int[5];
            int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };
            int[] arr2 = { 1, 2, 3, 4, 5 };

            int[] arr3;
            arr3 = new int[5] { 6, 7, 8, 9, 10 };
            //arr3 = { 0,9,9} //error

            //MULTI DIMENSIONAL ARRAY

            int[,] multiArr = new int[4, 2];
            //int[,] multiArr1 = new int[4, ]; // error
            int[,] multiArr1 = new int[,] { { 1, 2 }, { 3, 4 } };
            int[,] multiArr2 = new int[1, 2] { { 1, 2 } };

            int[][] multiArr3 = new int[2][];
            multiArr3[0] = new int[4] { 1, 2, 3, 4 };
            multiArr3[1] = new int[2] { 1, 2 };

            int[][] multiArr4 = {
                new int[4] { 1, 2, 3, 4 },
                new int[2] { 1, 2 } };



        }
    }

}
