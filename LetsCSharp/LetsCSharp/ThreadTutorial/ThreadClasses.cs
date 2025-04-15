using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.ThreadTutorial
{

    public delegate void SumOfNumbersDelegate(int sum);

    class TypeSafeForThread
    {
        private readonly int _value;
        private readonly string _name;
        public TypeSafeForThread(int value, string name) { _value = value; _name = name; }

        public void MethodRun()
        {

            Console.WriteLine($"{_name} Method Thread started");
            for (int i = 0; i < _value; i++)
            {
                Console.WriteLine($"{_name} Method : {i}");
            }
            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");
            Console.WriteLine($"{_name} Method Thread ended");
        }
    }

    class TypeSafeForThreadDelegate
    {
        private readonly int _value;
        private readonly string _name;

        private readonly SumOfNumbersDelegate _sumOfNumbersDelegate;

        public TypeSafeForThreadDelegate(int value, string name, SumOfNumbersDelegate sumOfNumbersDelegate)
        {
            _value = value;
            _name = name;
            _sumOfNumbersDelegate = sumOfNumbersDelegate;
        }

        public void MethodRun()
        {
            int sum = 0;
            Console.WriteLine($"{_name} Method Thread started");
            for (int i = 0; i < _value; i++)
            {
                sum += i;
                Console.WriteLine($"{_name} Method : {i}");
            }

            if (_sumOfNumbersDelegate != null)
                _sumOfNumbersDelegate.Invoke(sum);

            Console.WriteLine($"Thread name {Thread.CurrentThread.Name}");
            Console.WriteLine($"{_name} Method Thread ended");
        }
    }
}
