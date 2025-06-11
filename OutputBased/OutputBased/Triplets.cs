using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{

    // C# program to find all triplets having sum equal to
    // target by exploring all possible triplets

    class Triplets
    {
        static List<List<int>> FindTriplets(int[] arr, int target)
        {
            List<List<int>> res = new List<List<int>>();
            int n = arr.Length;

            // Generating all triplets
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {

                        // If the sum of triplet is equal to target
                        // then add it's indices to the result
                        if (arr[i] + arr[j] + arr[k] == target)
                        {
                            res.Add(new List<int> { i, j, k });
                        }
                    }
                }
            }
            return res;
        }

        public static void Main()
        {
            int[] arr = { 0, -1, 2, -3, 1 };
            int target = -2;

            List<List<int>> ans = FindTriplets(arr, target);
            foreach (var triplet in ans)
            {
                Console.WriteLine($"{triplet[0]} {triplet[1]} {triplet[2]}");
            }
        }
    }
}
