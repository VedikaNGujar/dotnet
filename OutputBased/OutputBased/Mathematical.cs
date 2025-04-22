using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class Mathematical
    {
        //How do you find the factorial of a number using recursion?
        public static int Factorial(int num)
        {
            return num == 0 ? 1 : num * Factorial(num - 1);
        }

        //How do you generate the Fibonacci sequence using recursion?
        public static int Fibonacci(int n)
        {
            return n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static void func2(out int num)
        {
            num = 10;
        }
        public static void AddOneToOddPosition(ref int[] arr)
        {
            //int x = 4, b = 2;
            //x -= b /= x * b;
            //Console.WriteLine(x + " " + b);
            //Console.ReadLine();

            Nullable<int> number = 0;
            int num = 1;
            Console.WriteLine(number.GetType() == num.GetType());

            Console.Write(" numbers are : ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    arr[i] = arr[i] + 1;
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
