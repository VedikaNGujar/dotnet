using LetsCSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{

    internal static class Ordering
    {


        public static void Test()
        {
            Console.WriteLine("---Ordering---");
            CommonHelper.InitializeData();

            Console.WriteLine("------");
            Console.WriteLine("Order by student name : With Lambda");
            Console.WriteLine("------");
            var resultStudentName = CommonHelper.Students.OrderBy(x => x.Name);
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));


            Console.WriteLine("------");
            Console.WriteLine("Order by student name : With SQL Like");
            Console.WriteLine("------");
            resultStudentName = (from student in CommonHelper.Students
                                 orderby student.Name ascending
                                 select student);
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

            Console.WriteLine("------");
            Console.WriteLine("Order by descending student name : With Lambda");
            Console.WriteLine("------");
            resultStudentName = CommonHelper.Students.OrderByDescending(x => x.Name);
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));


            Console.WriteLine("------");
            Console.WriteLine("Order by descending student name : With SQL Like");
            Console.WriteLine("------");
            resultStudentName = (from student in CommonHelper.Students
                                 orderby student.Name descending
                                 select student);
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

            Console.WriteLine("------");
            Console.WriteLine("Order by descending student name then by Fees : With Lambda");
            Console.WriteLine("------");
            resultStudentName = CommonHelper.Students.OrderByDescending(x => x.Name).ThenByDescending(x => x.Fees);
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Fees}"));


            Console.WriteLine("------");
            Console.WriteLine("Order by descending student name then by Fees : With SQL Like");
            Console.WriteLine("------");
            resultStudentName = (from student in CommonHelper.Students
                                 orderby student.Name descending, student.Fees descending
                                 select student);
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Fees}"));

            Console.WriteLine("------");
            Console.WriteLine("Before Reverse : With Lambda");
            Console.WriteLine("------");

            CommonHelper.Students.ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Fees}"));
            CommonHelper.Students.Reverse();

            Console.WriteLine("------");
            Console.WriteLine("After Reverse : With Lambda");
            Console.WriteLine("------");
            CommonHelper.Students.ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Fees}"));


        }
    }
}
