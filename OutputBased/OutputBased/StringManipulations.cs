using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class StringManipulations
    {
        //How do you count the occurrences of each character in a string?
        public static void StringOccurence(string str)
        {
            Console.WriteLine("------Approach1---------");

            var group = str
                .GroupBy(x => x)
                .Select(x => new { chr = x.Key, count = x.Count() });

            foreach (var item in group)
            {
                Console.WriteLine($"{item.chr} {item.count}");
            }


            /*--------------------------------------------------*/
            Console.WriteLine("------Approach2---------");

            var characterCount = str.GroupBy(c => c)
                            .ToDictionary(g => g.Key, g => g.Count());
            foreach (var item in characterCount)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

        }


        //How do you reverse words in a sentence?
        //Hello World"=> "World Hello
        public static void ReverseWordsInSentence(string str)
        {
            Console.WriteLine("------Approach1---------");
            var reverse = string.Join(" ", str.Split(" ").Reverse());
            Console.WriteLine($"Reverse : {reverse}");

        }
    }
}
