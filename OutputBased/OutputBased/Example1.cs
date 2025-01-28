using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class Example1
    {
        public void Test()
        {


            int[] i = new int[0];
            Console.WriteLine(i[0]);


#if (!pi)
            Console.WriteLine("i");
#else
                    Console.WriteLine("PI undefined");
#endif
            Console.WriteLine("ok");
            Console.ReadLine();
        }
    }
}
