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

            var resultStudentName = CommonHelper.Students.OrderBy(x => x.Name);
            Console.WriteLine("------");
            Console.WriteLine("Order by student name : With Lambda");
            Console.WriteLine("------");
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

            resultStudentName = (from student in CommonHelper.Students
                                 orderby student.Name ascending
                                 select student);
            Console.WriteLine("------");
            Console.WriteLine("Order by student name : With SQL Like");
            Console.WriteLine("------");
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

            resultStudentName = CommonHelper.Students.OrderByDescending(x => x.Name);
            Console.WriteLine("------");
            Console.WriteLine("Order by descending student name : With Lambda");
            Console.WriteLine("------");
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

            resultStudentName = (from student in CommonHelper.Students
                                 orderby student.Name descending
                                 select student);
            Console.WriteLine("------");
            Console.WriteLine("Order by descending student name : With SQL Like");
            Console.WriteLine("------");
            resultStudentName.ToList().ForEach(x => Console.WriteLine($"{x.Name}"));

        }
    }
}
