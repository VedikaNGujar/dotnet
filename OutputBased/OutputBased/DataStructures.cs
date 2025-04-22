using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class DataStructures
    {
        //How do you implement a Stack in C#?
        public static void StackCheck(int[] arr)
        {
            Console.WriteLine("-------Stack---------------");
            Stack<int> stack = new Stack<int>();
            foreach (var item in arr)
            {
                stack.Push(item);
            }

            for (int i = 0; i < stack.Count(); i++)
            {
                Console.WriteLine($"Peek : {stack.Peek()} Pop : {stack.Pop()}");
            }
        }

        //How do you implement a Queue in C#?
        public static void QueueCheck(int[] arr)
        {
            Console.WriteLine("-------Queue---------------");

            Queue<int> stack = new Queue<int>();
            foreach (var item in arr)
            {
                stack.Enqueue(item);
            }

            for (int i = 0; i < stack.Count(); i++)
            {
                Console.WriteLine($"Peek : {stack.Peek()} Pop : {stack.Dequeue()}");
            }
        }
    }
}
