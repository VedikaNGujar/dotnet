using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class OutputBasedQuestion1
    {
        public static void Ex1()
        {
            int[] arr = new int[2];
            arr[1] = 10;
            Object o = arr;
            int[] arr1 = (int[])o;
            arr1[1] = 100;
            Console.WriteLine(arr[1]);
            ((int[])o)[1] = 1000;
            Console.WriteLine(arr[1]);
        }

        public static void Ex2()
        {
            string[] strings = { "abc", "def", "ghi" };
            var actions = new List<Action>();
            foreach (string str in strings)
                actions.Add(() => { Console.WriteLine(str); });

            foreach (var action in actions)
                action();
        }
        public static void Ex3()
        {
            var actions = new List<Action>();
            for (int i = 0; i < 4; i++)
                actions.Add(() => Console.WriteLine(i));
            foreach (var action in actions)
                action();
        }
    }
}
