using CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsCSharp.Constructors
{
    public class ErrorExample
    {
        public ErrorExample(int a)
        {
            Helper.WriteLineWithTab("Parameterized Constructor");

        }
    }

    public class ErrorExample1
    {
        private ErrorExample1()
        {
            Helper.WriteLineWithTab("Private Constructor");

        }


        public void Instance()
        {
            var ex = new ErrorExample1(); //allowed here even if private as its privately accessed
        }

        public ErrorExample1 InstanceNew()
        {
            return new ErrorExample1(); //allowed here even if private as its privately accessed
        }

    }
}
