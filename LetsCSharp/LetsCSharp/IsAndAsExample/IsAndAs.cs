using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.IsAndAsExample
{
    public static class IsAndAs
    {
        public static void CheckIsKeyword()
        {
            object obj1 = "Vedika";
            if (obj1 is string)
                Console.WriteLine("obj1 is string");
            else
                Console.WriteLine("obj1 is not string");

            obj1 = 123;
            if (obj1 is string)
                Console.WriteLine("obj1 is string");
            else
                Console.WriteLine("obj1 is not string");


            int i = 5;
            object obj = i;
            int? intNullableObj = 10;
            if (obj is int x && intNullableObj is int y)
            {
                Console.WriteLine(x + y);
            }

            int? intNullableObj1 = null;
            if (obj is int x1 && intNullableObj1 is int y1)
            {
                Console.WriteLine(x1 + y1);
            }

            if (intNullableObj is null)
                Console.WriteLine("intNullableObj is null");
            if (intNullableObj is not null)
                Console.WriteLine("intNullableObj is not null");

        }

        public static void CheckAsKeyword()
        {
            EmployeeAs employeeAs = new EmployeeAs();
            object obj = employeeAs;
            try
            {
                string str = (string)obj;//this will throw error
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            string str1 = obj as string; // will return null;
            Console.WriteLine($"Result is : {(str1 == null ? "null" : "not null")} : string str1 = obj as string");

            EmployeeAs employeeAs1 = obj as EmployeeAs; //will succeed
            Console.WriteLine($"Result is : {employeeAs1} : obj as EmployeeAs");


        }
    }

    public class EmployeeAs
    {

    }
}
