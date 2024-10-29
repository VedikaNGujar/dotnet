using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Constant
{
    internal class Constant
    {
        //public static const int k = 20; // cannot do this, static cannot be marked with const
        public static readonly int l = 20; // can do this
        public const int i = 10;
        //public const int j; //this much defined during declaration
        public Constant(int value)
        {
            //this.i = value; //error, as constanct value cant be chnaged throughout the lifecycle
        }

        public void SetValue()
        {
            const int j = 10; // can do this
            //readonly int k = 20; //cannot do this
        }
    }
}
