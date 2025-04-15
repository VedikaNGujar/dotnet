using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.ThreadTutorial
{

    internal class ThreadTutorial
    {
        public void ThreadTutorial1()
        {
            Thread t = Thread.CurrentThread;
            t.Name = "Main Thread";
            Console.WriteLine($"Thread name {t.Name}");
            Console.WriteLine($"Main Thread name {Thread.CurrentThread.Name}");
        }


        public void MultipleThreadTutorial()
        {

            Console.WriteLine("Main Thread started");

            Thread t1 = new Thread(Method1)
            {
                Name = "Thread 1"
            };

            Thread t2 = new Thread(Method2)
            {
                Name = "Thread 2"
            };
            Thread t3 = new Thread(Method3)
            {
                Name = "Thread 3"
            };

            t1.Start();
            t2.Start();
            t3.Start();
            Console.WriteLine("Main Thread ended");

        }

        public void ParameterizedThreadTutorial()
        {

            Console.WriteLine("Main Thread started");

            ParameterizedThreadStart parameterizedThreadStart =
                new ParameterizedThreadStart(MethodArgument);

            Thread t1 = new Thread(parameterizedThreadStart)
            {
                Name = "Thread 1 With parameters passed "

            };

            t1.Start(10);

            Thread t2 = new Thread(parameterizedThreadStart)
            {
                Name = "Thread 2 With No parameters passed "
            };

            t2.Start();

            Console.WriteLine("Main Thread ended");

        }

        public void ParameterizedTypeSafeThreadTutorial()
        {

            Console.WriteLine("Main Thread started");

            TypeSafeForThread t = new TypeSafeForThread(10, "thread 1");

            Thread t1 = new Thread(t.MethodRun)
            {
                Name = "Thread 1 "

            };

            t1.Start();

            t = new TypeSafeForThread(20, "thread 2");

            Thread t2 = new Thread(t.MethodRun)
            {
                Name = "Thread 2"
            };

            t2.Start();

            Thread t3 = new Thread(() => MethodTypeSafe(5))
            {
                Name = "Thread 2"
            };

            t3.Start();
            Console.WriteLine("Main Thread ended");

        }
        private void MethodTypeSafe(int value)
        {
            Console.WriteLine("Method 1 Thread started");
            for (int i = 0; i < value; i++) { Console.WriteLine($"Method 1 : {i}"); }
            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");
            Console.WriteLine("Method 1 Thread ended");
        }

        public void ParameterizedTypeSafeWithReturnValueThreadTutorial()
        {

            Console.WriteLine("Main Thread started");
            SumOfNumbersDelegate sumOfNumbersDelegate = sumOfNumbers;

            TypeSafeForThreadDelegate t = new TypeSafeForThreadDelegate(10, "thread 1", sumOfNumbersDelegate);

            Thread t1 = new Thread(t.MethodRun)
            {
                Name = "Thread 1 "

            };

            t1.Start();

            t = new TypeSafeForThreadDelegate(20, "thread 2", sumOfNumbers);

            Thread t2 = new Thread(t.MethodRun)
            {
                Name = "Thread 2"
            };

            t2.Start();
            Console.WriteLine("Main Thread ended");

        }


        public void ThreadJoinAndIsAlive()
        {
            Console.WriteLine("Main Started");
            Thread T1 = new Thread(Thread1Function);
            T1.Start();

            Thread T2 = new Thread(Thread2Function);
            T2.Start();

            if (T1.Join(1000))
            {
                Console.WriteLine("Thread1Function completed");
            }
            else
            {
                Console.WriteLine("Thread1Function has not completed in 1 second");
            }

            T2.Join();
            Console.WriteLine("Thread2Function completed");

            Console.WriteLine($"Thread1Function is Alive ? {T1.IsAlive}");

            if (T1.IsAlive)
            {
                T1.Join();
            }

            Console.WriteLine($"Thread1Function is Alive ? {T1.IsAlive}");


            Console.WriteLine("Main Completed");
        }


        private void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1Function is about to return");
        }

        private void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }


        public void sumOfNumbers(int sum)
        {
            Console.WriteLine("Sum of numbers : " + sum);
        }


        private void MethodArgument(object? obj)
        {
            int argu = obj != null ? (int)obj : 20;
            Console.WriteLine("MethodArgument Thread started");
            for (int i = 0; i < argu; i++) { Console.WriteLine($"MethodArgument : {i}"); }
            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");
            Console.WriteLine("MethodArgument Thread ended");
        }

        private void Method1()
        {
            Console.WriteLine("Method 1 Thread started");
            for (int i = 0; i < 10; i++) { Console.WriteLine($"Method 1 : {i}"); }
            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");
            Console.WriteLine("Method 1 Thread ended");
        }

        private void Method2()
        {
            Console.WriteLine("Method 2 Thread started");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Method 2 : {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");

            Console.WriteLine("Method 2 Thread ended");
        }

        private void Method3()
        {
            Console.WriteLine("Method 3 Thread started");
            for (int i = 0; i < 10; i++) { Console.WriteLine($"Method 3 : {i}"); }
            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");

            Console.WriteLine("Method 3 Thread ended");
        }

    }
}
