using System;
using System.Collections.Generic;
using System.Text;

namespace LetsCSharp.Struct
{

    public struct Struct1
    {

        //public Struct1()// cannot have parameter less struct
        //{

        //}

        public int x; public int y;

        public Struct1(int x, int y) // is allowed
        {
            this.x = x;
            this.y = y;
        }
    }


    public struct Struct2 // : Struct1 connot inherit structures from another struct
    {

    }


    public class Class1 // : Struct1 connot inherit structures from another struct
    {
    }

    public struct Struct3 : Interface1//interfaces are allowedg //:Class1  connot inherit structures from another classes
    {

    }

    public interface Interface1 //:Class1  connot inherit structures from another classes
    {

    }
}
