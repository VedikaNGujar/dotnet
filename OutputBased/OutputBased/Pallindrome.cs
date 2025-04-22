using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{

    internal class Pallindrome
    {

        public static bool Approach2(string input)
        {
            string reversed = new string(input.Reverse().ToArray());
            return input.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        public static bool Approach1(string word)
        {
            int length = word.Length - 1;
            for (int i = 0; i < word.Length / 2; i++, length--)
            {
                if (!word[i].Equals(word[length]))
                    return false;
            }
            return true;
        }
    }
}
