using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Delegates
{
    internal class DelegateEx
    {
        public delegate void HelloFucntionDelegate(string msg);
        public delegate void MultiCastDelegate(string msg);

        public void HelloFunction(string msg)
        {
            Console.WriteLine("HelloFunction1");
            Console.WriteLine(msg);
        }
        public void HelloFunction2(string msg)
        {
            Console.WriteLine("HelloFunction2");
            Console.WriteLine(msg);
        }
        public void HelloFunction3(string msg)
        {
            Console.WriteLine("HelloFunction3");
            Console.WriteLine(msg);
        }

        public void TestDelegate()
        {
            HelloFucntionDelegate hfd = new HelloFucntionDelegate(HelloFunction);
            hfd.Invoke("Heyaa");
        }



        public void TestDelegateMulticast()
        {
            MultiCastDelegate hfd = new MultiCastDelegate(HelloFunction);
            //hfd.Invoke("Heyaafrom1");
            hfd += new MultiCastDelegate(HelloFunction2);
            hfd += new MultiCastDelegate(HelloFunction3);
            hfd.Invoke("mesage will be same for all functions");
            hfd -= new MultiCastDelegate(HelloFunction2);
            hfd.Invoke("mesage will be same for all functions");

        }

    }
}
