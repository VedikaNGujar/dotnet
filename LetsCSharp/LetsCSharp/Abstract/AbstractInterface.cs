using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Abstract
{

    internal interface InterfaceForAbstract
    {
        public abstract void Getname();
    }

    internal interface InterfaceForAbstract1 : InterfaceForAbstract
    {
        public new abstract void Getname();
    }

    internal abstract class Abstract2 : InterfaceForAbstract1
    {
        public abstract void Getname();
    }


    internal abstract class Abstract3 : Abstract2
    {
        public override void Getname()
        {
            Console.WriteLine("getname");
        }
    }

    internal abstract class Abstract1
    {
        public int i;// is allowed
        public int j
        {
            get; set;
        }

        public abstract void Getname();
        public void Getname2()
        {
            Console.WriteLine("getName2");
        }

        public virtual void Getname3()
        {
            Console.WriteLine("getName3");
        }
    }

    internal class ClassAbstract1 : Abstract1
    {
        public override void Getname()
        {
            Console.WriteLine("getName child class");

        }
        public override void Getname3()
        {
            Console.WriteLine("getName3 child class");
        }
    }
}
