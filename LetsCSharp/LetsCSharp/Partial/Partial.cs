﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Partial
{
    public partial class Partial
    {
        public int i;
        partial void Display()
        {
            Console.WriteLine("");
        }
    }
    public partial class Partial
    {
        public int j;
        partial void Display();
        partial void Display1(ref int j); // allowed but cannot have out
        //partial void Display2(out int j); // not allowed as method has out

    }


    public class PartialExtend : Partial
    {
        public void Display()
        {
            //base.Display();// cannot access becase by default partial methods are private
        }
    }

    public class PartialEx
    {
        public void Test()
        {
            Partial partial = new();
            partial.i = 1;
            partial.j = 2;
        }

    }
}