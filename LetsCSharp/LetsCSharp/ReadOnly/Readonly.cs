using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.ReadOnly
{
    internal class Readonly
    {
        public readonly string String1;
        public readonly string String2 = "abc";
        public readonly string String3 = "xyz";

        public string SetValue
        {
            get => String1;
            //set { String1 = value; } // cannot set
        }
        public Readonly()
        {
            String1 = "Change";
            String2 = "abcChange";
            String3 = "xyzChange";
        }
        public Readonly(string str)
        {
            String1 = str;
        }
        public void Test()
        {
            //   String1 = ""; // error cannot set
        }
    }


    public class Reads
    {
        public int i;
        public readonly int j;
        public Reads(int i, int j) { this.i = i; this.j = j; }
    }

    public class ReadonlyRefCheck
    {
        public readonly string str1 = "abc";
        public readonly Reads R1 = new Reads(10, 20);
        public readonly Reads R2 = new Reads(30, 20);
        public ref readonly Reads R3
        {
            get { return ref R2; }
            //set { R4 = value; } error return by reference cannot have set acccessors
        }

        public ReadonlyRefCheck()
        {
            str1 = "xyz";//allowed
            R1 = new Reads(20, 40);//allowed
            R2 = new Reads(20, 50);//allowed
            //R3 = new Reads(30);// not allowed as it has only get accessors
        }

        public void SetValue()
        {
            //str1 = "xyz";//error as its readonly
            R1.i = 1; //is allowed
            R2.i = 2;//is allowed
            R3.i = 30;//is also allowed as both are reference types and not value types
            //R3.j = 40;//will throw error as j is readonly 
        }
    }
}
