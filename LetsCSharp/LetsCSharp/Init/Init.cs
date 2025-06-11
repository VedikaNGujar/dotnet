using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Init
{
    public class Init
    {

        public Init()
        {
            k = 10; //allowed here
        }

        public int k { get; }
        public int i { get; init; }
        public int j { get; init; }
    }

    public class InitDerived : Init
    {
        public InitDerived()
        {
            //base.k = 10;// not allowed
            base.i = 10;// allowed
        }
    }


    internal static class InitExample
    {

        public static void Test()
        {

            var initC = new Init()
            {
                i = 1, //allowed
                       //k = 10, not allowed here to happen we can use init
            };
            // initC.i = 10;//not allowed

            //initC.k = 2;//not allowed here
            Console.WriteLine($"i : {initC.i} j : {initC.j}");
        }
    }
}
