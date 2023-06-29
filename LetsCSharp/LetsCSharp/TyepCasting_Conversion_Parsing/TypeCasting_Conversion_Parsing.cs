using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.TyepCasting_Conversion_Parsing
{
    public static class TypeCasting_Conversion_Parsing
    {
        //conversion from one data to another using 3 ways
        //type conversion - done by compiler
        //type casting - done by programmer
        //parsing examples - specificly designed to parse to primitive data type

        public static void TypeConversion()
        {
            //automatically converted to another data type by compiler
            //we dont need to do anything extra
            //both data type should be compatible
            //target data type should be greater that source data type
            //then there will be no loss
            //byte>short>int>long>float>double

            int i = 1000;
            double d = i;
            Console.WriteLine(d);

            //double d1 = 31.13455;
            //int i1 = d;   //error
            //Console.WriteLine(i1);

        }

        public static void TypeCasting()
        {
            //process to convert larger data type to smaller 

            double d = 31.545677;
            double d1 = 31.145677;
            int i = (int)d;//loss of data of 0.545677
            Console.WriteLine(i);

            int i1 = Convert.ToInt32(d); // it round the number;
            Console.WriteLine(i1);

            i1 = Convert.ToInt32(d1); // it round the number;
            Console.WriteLine(i1);

        }

        public static void ParseAndTryParse()
        {
            //Parse throws expection
            //Tryparse returns boolean

            string s1 = "100";
            string s2 = "Test";
            string s3 = "21345678911110";
            string s4 = null;
            string s5 = "100.25";
            string s6 = "1005f";


            try
            {
                int i1 = int.Parse(s1);
                Console.WriteLine($"{i1}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }
            try
            {
                int i2 = int.Parse(s2);
                Console.WriteLine($"{i2}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);


            }
            try
            {
                int i3 = int.Parse(s3);
                Console.WriteLine($"{i3}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);


            }
            try
            {
                int i4 = int.Parse(s4);
                Console.WriteLine($"{i4}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);


            }
            try
            {
                int i5 = int.Parse(s5);
                Console.WriteLine($"{i5}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);


            }
            try
            {
                int i6 = int.Parse(s6);
                Console.WriteLine($"{i6}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }


            try
            {
                bool b1 = int.TryParse(s1, out int i1);
                Console.WriteLine($"{b1}::{i1}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            try
            {
                bool b2 = int.TryParse(s2, out int i2);
                Console.WriteLine($"{b2}::{i2}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);


            }
            try
            {
                bool b3 = int.TryParse(s3, out int i3);
                Console.WriteLine($"{b3}::{i3}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }
            try
            {
                bool b4 = int.TryParse(s4, out int i4);
                Console.WriteLine($"{b4}::{i4}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }
            try
            {
                bool b5 = int.TryParse(s5, out int i5);
                Console.WriteLine($"{b5}::{i5}");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception for int i5 = int.Parse(s5)");

            }
            try
            {
                bool b6 = int.TryParse(s6, out int i6);
                Console.WriteLine($"{b6}::{i6}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }
        }

    }
}
