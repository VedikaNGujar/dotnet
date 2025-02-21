using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Generics
{

    //concept of type parameter in .Net
    //Code Reuse, performace and Type Safety
    //Generics on class, methods, interfacess and delegates
    public static class Generic
    {
        public static bool AreEqual<T>(T a, T b)
        {
            return a.Equals(b);
        }

    }

    public class GenericList<T> // generic clas
    {
        private List<T> list = new List<T>();
        public void Add(T input)
        {
            list.Add(input);
        }

        public void PrintList()
        {
            list.ForEach(x => Console.WriteLine(x));
        }
    }

    public interface GenericInterface<T> // generic interface
    {
        public List<T> List { get; set; }
        public void Add(T input);

        public void PrintList();
    }

    public class OverideGenericInterface : GenericInterface<int>
    {
        public List<int> List
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Add(int input)
        {
            throw new NotImplementedException();
        }

        public void PrintList()
        {
            throw new NotImplementedException();
        }
    }

    public class OverideGenericInterface1 : GenericInterface<string>
    {
        public List<string> List
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Add(string input)
        {
            throw new NotImplementedException();
        }

        public void PrintList()
        {
            throw new NotImplementedException();
        }
    }

    public class ExampleClass { }

    public class GenericExample
    {
        public void Test()
        {
            // Declare a list of type int.
            GenericList<int> list1 = new GenericList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.PrintList();

            // Declare a list of type string.
            GenericList<string> list2 = new GenericList<string>();
            list2.Add("Test 1");
            list2.Add("Test 2");
            list2.Add("Test 3");
            list2.PrintList();

            // Declare a list of type ExampleClass.
            GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
            list3.Add(new ExampleClass());
        }
    }
}
