using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Delegates
{
    internal class PredicateTest
    {
        public bool IsEven(int number) => number % 2 == 0;
        public void CheckPredicate()
        {
            Predicate<int> predicate = IsEven;
            var result = predicate(10);

            Predicate<string> predicateWithLambda = (str) => !string.IsNullOrEmpty(str);

            result = predicateWithLambda("Vedika");
            result = predicateWithLambda(null);

            Predicate<int> predicateWithDelegate = delegate (int number)
            {
                return number % 2 == 0;
            };

            result = predicateWithDelegate(25);
        }
    }

    internal class ActionTest
    {
        public void PrintFullName(string firstName, string lastName)
            => Console.WriteLine($"{firstName} {lastName}");
        public void CheckAction()
        {
            Action<string, string> action = PrintFullName;
            action("Vedika", "Gujar");

            Action<string, string> actionWithLambda
                = (firstName, lastName)
                => Console.WriteLine($"{firstName} {lastName}");

            actionWithLambda("Vedika", "Gujar");

            Action<string, string> actionWithDelegate = delegate (string firstName, string lastName)
            {
                Console.WriteLine($"{firstName} {lastName}");
            };
            actionWithDelegate("Vedika", "Gujar");
        }
    }

    internal class FunctionTest
    {
        public string GetFullName(string firstName, string lastName)
            => $"{firstName} {lastName}";

        public void CheckFunction()
        {
            Func<string, string, string> func = GetFullName;
            Console.WriteLine(func("Vedika", "Gujar"));

            Func<string, string, string> funcWithLambda
                = (firstName, lastName)
                => $"{firstName} {lastName}";

            Console.WriteLine(funcWithLambda("Vedika", "Gujar"));

            Func<string, string, string> funcWithDelegate
                = delegate (string firstName, string lastName)
            {
                return $"{firstName} {lastName}";
            };
            Console.WriteLine(funcWithDelegate("Vedika", "Gujar"));
        }
    }
}
