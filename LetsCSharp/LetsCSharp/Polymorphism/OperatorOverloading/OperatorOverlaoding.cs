using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Polymorphism.OperatorOverloading
{

    public class Math2
    {
        private readonly int num1;
        private readonly int num2;

        public int Num1 => num1;
        public int Num2 => num2;

        public Math2(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }


    }
    public class Math
    {
        private readonly int num1;
        private readonly int num2;

        public Math(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public static Math operator +(Math left)
        {
            return new Math(left.num1 + 10, left.num2 + 10);
        }

        public static Math operator +(Math left, Math2 math2)
        {
            return new Math(left.num1 + math2.Num1, left.num2 + math2.Num2);
        }
        public static Math operator -(Math left, Math2 math2)
        {
            return new Math(left.num1 - math2.Num1, left.num2 - math2.Num2);
        }

        public static Math operator -(Math left)
        {
            return new Math(left.num1 - 10, left.num2 - 10);
        }

        public static Math operator *(Math left, Math right)
        {
            return new Math(left.num1 * right.num1, left.num2 * right.num2);
        }

        public static Math operator /(Math left, Math right)
        {
            return new Math(left.num1 / right.num1, left.num2 / right.num2);
        }

        public override string ToString() => $"num1 {num1} - num2 {num2}";
    }


    public static class OperatorOverloading
    {
        public static void Test()
        {

            Math math = new Math(10, 20);
            Console.WriteLine((+math).ToString());
            Console.WriteLine((-math).ToString());

            Math math1 = new Math(5, 5);
            Console.WriteLine((math * math1).ToString());
            Console.WriteLine((math / math1).ToString());


            Math2 math2 = new Math2(5, 5);
            Console.WriteLine((math + math2).ToString());
            Console.WriteLine((math - math2).ToString());


        }
    }




    //public readonly struct Fraction
    //{
    //    private readonly int num;
    //    private readonly int den;

    //    public Fraction(int numerator, int denominator)
    //    {
    //        if (denominator == 0)
    //        {
    //            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
    //        }
    //        num = numerator;
    //        den = denominator;
    //    }

    //    public static Fraction operator +(Fraction a) => a;
    //    public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

    //    public static Fraction operator +(Fraction a, Fraction b)
    //        => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

    //    public static Fraction operator -(Fraction a, Fraction b)
    //        => a + (-b);

    //    public static Fraction operator *(Fraction a, Fraction b)
    //        => new Fraction(a.num * b.num, a.den * b.den);

    //    public static Fraction operator /(Fraction a, Fraction b)
    //    {
    //        if (b.num == 0)
    //        {
    //            throw new DivideByZeroException();
    //        }
    //        return new Fraction(a.num * b.den, a.den * b.num);
    //    }

    //    public override string ToString() => $"{num} / {den}";
    //}

    //public static class OperatorOverloading
    //{
    //    public static void Main()
    //    {
    //        var a = new Fraction(5, 4);
    //        var b = new Fraction(1, 2);
    //        Console.WriteLine(-a);   // output: -5 / 4
    //        Console.WriteLine(a + b);  // output: 14 / 8
    //        Console.WriteLine(a - b);  // output: 6 / 8
    //        Console.WriteLine(a * b);  // output: 5 / 8
    //        Console.WriteLine(a / b);  // output: 10 / 4
    //    }
    //}
}
