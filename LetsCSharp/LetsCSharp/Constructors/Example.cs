using CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsCSharp.Constructors
{
    public class Example
    {
        public Example()
        {
            Helper.WriteLineWithTab("Default Constructor");
        }
        public Example(int a)
        {
            Helper.WriteLineWithTab("Parameterized Constructor");
        }
        ~Example() // access specifiers not allowed
        {
            Helper.WriteLineWithTab("Destructors");
        }

    }
}
