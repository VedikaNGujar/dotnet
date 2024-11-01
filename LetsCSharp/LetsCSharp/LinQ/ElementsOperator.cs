using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{
    internal static class ElementsOperator
    {
        //min, max, sum, count, average
        public static void Test()
        {
            Console.WriteLine("---Elements Operator---");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Console.WriteLine("First : " + numbers.First());
            Console.WriteLine("FirstOrDefault : " + numbers.FirstOrDefault());

            Console.WriteLine("Last : " + numbers.Last());
            Console.WriteLine("LastOrDefault : " + numbers.LastOrDefault());


            //Console.WriteLine("First : " + numbers.First(x => x > 16)); //will throw error
            Console.WriteLine("FirstOrDefault : " + numbers.FirstOrDefault(x => x > 16)); //will return 0
                                                                                          //as there is not element above 16

            //Console.WriteLine("Last : " + numbers.Last(x => x > 16)); //will throw error
            Console.WriteLine("LastOrDefault : " + numbers.LastOrDefault(x => x > 16)); //will return 0
                                                                                        //as there is not element above 16


            Console.WriteLine("ElementAt : " + numbers.ElementAt(14));
            //Console.WriteLine("ElementAt : " + numbers.ElementAt(17)); //will throw error
            Console.WriteLine("ElementAtOrDefault : " + numbers.ElementAtOrDefault(19)); //will return 0
                                                                                         //as there is not element above 16


            Console.WriteLine("Single : " + numbers.Single(x => x == 1));
            //Console.WriteLine("Single : " + numbers.Single(x => x % 2 == 0)); //will throw error
            //Console.WriteLine("SingleOrDefault : " + numbers.SingleOrDefault(x => x % 2 == 0)); //will still throw error
            Console.WriteLine("SingleOrDefault : " + numbers.SingleOrDefault(x => x == 0));

            Console.WriteLine("DefaultIfEmpty : ");
            numbers.DefaultIfEmpty(10).ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine("\nDefaultIfEmpty 10 : ");
            List<int> numbers1 = new List<int>();
            numbers1.DefaultIfEmpty(10).ToList().ForEach(x => Console.WriteLine(x));




        }
    }
}
