using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Sealed
{
    public sealed class Sealed // sealed to prevent other class inheriting from it

    {
    }

    //public class SealedInherit : Sealed //error
    //{ }

    //public abstract sealed class Sealed1 // error dont use abstract and
    // sealed together and abstract is meant to be overridden


    public abstract class SealedMethodTest
    {
        public virtual void F1() => Console.WriteLine("hey1");
        public virtual void F2() => Console.WriteLine("hey2");
        public abstract void F3();//=> Console.WriteLine("hey3");
    }

    public class SealedMethodTest1 : SealedMethodTest
    {
        public sealed override void F1() => Console.WriteLine("hey1"); // so this can't be furture overridden
        public override void F2() => Console.WriteLine("hey2");
        public override void F3() => Console.WriteLine("hey3");
    }

    public class SealedMethodTest2 : SealedMethodTest1
    {
        //public sealed override void F1() => Console.WriteLine("hey1"); // error
        public override void F2() => Console.WriteLine("hey2"); //allowed as its not sealed
    }
}
