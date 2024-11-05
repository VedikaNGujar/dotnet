using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.AsyncAwait
{
    internal static class AsyncAwait
    {
        public static async void Test()
        {
            string result = await SimulateAsyncAwaitOperation();
            Console.WriteLine(result);

            //multiple tasks
            //when all
            Task<string> task1 = SimulateAsyncAwaitOperation();
            Task<string> task2 = SimulateAsyncAwaitOperation2();
            string[] results = await Task.WhenAll(task1, task2);
            foreach (var newResult in results) Console.WriteLine(newResult);

        }

        private static async Task<string> SimulateAsyncAwaitOperation()
        {
            await Task.Delay(1000);
            return "Operation Completed";
        }

        private static async Task<string> SimulateAsyncAwaitOperation2()
        {
            await Task.Delay(2000);
            return "Operation Completed";
        }
    }
}
