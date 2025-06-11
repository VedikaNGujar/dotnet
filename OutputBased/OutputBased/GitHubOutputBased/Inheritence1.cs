using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased.GitHubOutputBased
{

    public class Inheritence1
    {
        public static void Test()
        {
            //Base Class  Constructor
            //Class Derived Constructor
            //Class Derived MethodA
            //Base Class  Constructor
            //Class Derived Parameterized Constructor
            //Class Derived MethodA
            //0 20 20
            Derived obj = new Derived();
            obj.MethodA();
            Console.WriteLine("****************");
            Derived obj1 = new Derived(12);
            obj1.MethodA();
            Console.WriteLine("****************");
            Derived obj2 = obj1;
            obj2.Count = 20;
            Console.WriteLine(obj.Count + " " + obj1.Count + " " + obj2.Count);
        }
    }
    public class Base
    {
        public int Count;

        public Base()
        {
            Console.WriteLine("Base Class  Constructor");
        }
        public Base(int cnt)
        {
            Count = cnt;
            Console.WriteLine(" Class Base Parameterized Constructor");

        }
        public void MethodB()
        {
            Console.WriteLine("Base Class  MethodB");
        }
    }

    public class Derived : Base
    {

        public int Count;

        public Derived()
        {
            Console.WriteLine(" Class Derived Constructor");
        }
        public Derived(int cnt)
        {
            Count = cnt;
            Console.WriteLine(" Class Derived Parameterized Constructor");

        }

        public void MethodA()
        {
            Console.WriteLine(" Class Derived MethodA");
        }
    }
}
