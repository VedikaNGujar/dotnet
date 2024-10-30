using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.VarDynamicAnonymous
{
    internal class VarDynamicAnonymous
    {
        //public var i = 10; //var can be used as local variable
        //public var i { get;set; } // not allowed

        public dynamic i1 = 10; //allowed
        public dynamic j1 { get; set; } //allowed

        public void VarDynamicAnonymousTest()
        {
            //var is compile time type 
            var i = 0;
            var j = 0;
            // j = "j1"; // not allowed, as j is integer

            //dynamic is runtime type
            dynamic s = "string";
            s = 12e3; // allowed
            s = 4.5; // allowed

            var anonymous = new
            {
                FN = "Vedika",
                LN = "Gujar",
                Address = new
                {
                    City = "Pune",
                    State = "Maharastra"
                }
            };

            Console.WriteLine($"FullName : {anonymous.FN} {anonymous.LN}");
            Console.WriteLine($"Address : {anonymous.Address.State} {anonymous.Address.City}");

        }

        //public void Test(var i,var j) { } //error

        public dynamic Test(dynamic i, out dynamic j) { j = 0; return 123; } //allowed as
                                                                             //"return,out" also
    }
}
