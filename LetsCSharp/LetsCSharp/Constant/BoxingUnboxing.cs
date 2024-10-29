using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Constant
{
    internal class BoxingUnboxing
    {

        public void SetValue()
        {
            int i = 0;
            object obj = i;// boxing

            object obj1 = 10;
            int j = (int)obj1; //unboxing

        }
    }
}
