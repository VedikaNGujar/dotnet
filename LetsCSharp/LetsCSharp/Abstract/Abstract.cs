using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Abstract
{
    internal abstract class Abstract
    {
        public int i;// is allowed
        public int j
        {
            get; set;
        }

        public abstract void Getname();
        public virtual void GetName3()
        {
            Console.WriteLine("Base:GetName3");

        }
        public void Getname2()
        {
            Console.WriteLine("Base:GetName2");
        }

        public virtual void Getname3()
        {
            Console.WriteLine("Base:GetName3");
        }
    }

    internal class ClassAbstract : Abstract
    {
        public override void Getname()
        {
            Console.WriteLine("Child:GetName child class");

        }
        public override void Getname3()
        {
            Console.WriteLine("Child:GetName3 child class");
        }
    }



}
