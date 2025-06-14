﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class SplitArrays
    {
        public static void Main()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            SplitArray(array, 3);
        }

        public static void SplitArray(int[] array, int splitArrayCount)
        {
            int[][] jaggedArray = new int[splitArrayCount][];
            var numberOfElementsInEachArray = array.Length / splitArrayCount;
            Console.WriteLine("***" + numberOfElementsInEachArray + "***");
            for (int i = 0; i < splitArrayCount; i++)
            {
                jaggedArray[i] = array.Skip(i * numberOfElementsInEachArray).Take(numberOfElementsInEachArray).ToArray();
            }
            Console.WriteLine("$$$" + jaggedArray.Length + "$$$");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine("---------------");
                int[] innerArray = jaggedArray[i];
                for (int j = 0; j < innerArray.Length; j++)
                {
                    Console.WriteLine(innerArray[j]);
                }
            }
        }

    }
}
