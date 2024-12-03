using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    //Q.1: How to reverse a string?
    //Ans.: The user will input a string and the method should return the reverse of that string

    //input: hello, output: olleh
    //input: hello world, output: dlrow olleh
    internal static class ReverseString
    {
        public static string Approach1(string word)
        {
            if (string.IsNullOrEmpty(word)) { return word; }
            else
            {
                char[] charArr = word.ToCharArray();
                for (int i = 0, j = word.Length - 1; i < charArr.Length && j >= 0; i++, j--)
                {
                    charArr[i] = word[j];
                    charArr[j] = word[i];
                }
                return new string(charArr);

            }
        }


        public static string Approach2(string word)
        {
            if (string.IsNullOrEmpty(word)) { return word; }
            else
            {
                StringBuilder reverse = new StringBuilder();
                for (int j = word.Length - 1; j >= 0; j--)
                {
                    reverse.Append(word[j]);
                }
                return reverse.ToString();
            }
        }
    }
}
