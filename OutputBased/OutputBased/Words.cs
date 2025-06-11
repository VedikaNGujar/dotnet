using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    public static class Words
    {
       public static string RearrangeWord(string word)
        {
            char[] chars = word.ToCharArray();
            int i = chars.Length - 2;

            // Step 1: Find the rightmost character which is smaller than its next character
            while (i >= 0 && chars[i] >= chars[i + 1])
            {
                i--;
            }

            // If no such character is found, this is the last permutation
            if (i < 0)
            {
                return "no answer";
            }

            // Step 2: Find the rightmost character that is greater than chars[i]
            int j = chars.Length - 1;
            while (chars[j] <= chars[i])
            {
                j--;
            }

            // Step 3: Swap them
            Swap(chars, i, j);

            // Step 4: Reverse the suffix starting at i + 1
            Array.Reverse(chars, i + 1, chars.Length - (i + 1));

            return new string(chars);
        }

        static void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

       

    }
}
