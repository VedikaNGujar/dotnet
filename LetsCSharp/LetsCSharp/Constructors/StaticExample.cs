using CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsCSharp.Constructors
{
    public class StaticExample
    {
        static StaticExample() // no access specifiers allowed and will be called only once and shared by all objects
        {
            Helper.WriteLineWithTab("Static Constructor");
        }
        public StaticExample() : this(1) //Parameterised constructor will be called first and then the default constructor
        {
            Helper.WriteLineWithTab("Default Constructor");
        }
        public StaticExample(int a)
        {
            Helper.WriteLineWithTab("Parameterized Constructor");
        }
        ~StaticExample() // access specifiers not allowed
        {
            Helper.WriteLineWithTab("Destructors");
        }

    }
}
