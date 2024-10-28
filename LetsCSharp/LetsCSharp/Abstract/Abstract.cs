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
        public void Getname2()
        {
            Console.WriteLine("getName2");
        }

        public virtual void Getname3()
        {
            Console.WriteLine("getName3");
        }
    }

    internal class ClassAbstract : Abstract
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
