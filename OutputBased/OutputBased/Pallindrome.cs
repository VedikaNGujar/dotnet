using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{

    public sealed class Singleton5
    {
        private Singleton5()
        {
        }
        private static readonly Lazy<Singleton5> lazy = new Lazy<Singleton5>();
        public static Singleton5 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
    public class A
    {
        private A() { }
        public A(int i) { }
    }
    public class B : A
    {
        public B() : base(10) { }
    }

    internal class Pallindrome
    {
        public static bool Approach1(string word)
        {
            return true;
        }
    }
}
