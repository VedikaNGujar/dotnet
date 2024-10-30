using LetsCSharp.Common;
using LetsCSharp.Polymorphism.MethodHiding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{


    internal static class Projection
    {

        public static void Test()
        {
            Console.WriteLine("---Projection---");

            CommonHelper.InitializeData();

            var resultEmpName = CommonHelper.Students.Select(x => x.Name);
            Console.WriteLine("------");
            Console.WriteLine("Print Employee Names : ");
            Console.WriteLine("------");
            resultEmpName.ToList().ForEach(x => Console.WriteLine(x));

            var resultAnony = CommonHelper.Students.Where(x => x.Fees > 1000).Select(x => new { x.Name, x.Gender });
            Console.WriteLine("------");
            Console.WriteLine("Print students with fees greater than 1000 : ");
            Console.WriteLine("------");
            resultAnony.ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.Gender}"));

            var resultSubjects = CommonHelper.Students.SelectMany(x => x.Subjects);
            Console.WriteLine("------");
            Console.WriteLine("SelectMany : Print Subjects : With Lambda");
            Console.WriteLine("------");
            resultSubjects.ToList().ForEach(x => Console.WriteLine($"{x.Title}"));

            resultSubjects = (from student in CommonHelper.Students
                              from subject in student.Subjects
                              select subject);
            Console.WriteLine("------");
            Console.WriteLine("SelectMany : Print Subjects : With SQL Like");
            Console.WriteLine("------");
            resultSubjects.ToList().ForEach(x => Console.WriteLine($"{x.Title}"));

            string[] stringArray = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "1234567890" };
            Console.WriteLine("------");
            Console.WriteLine("SelectMany : Print chars : With Lambda");
            Console.WriteLine("------\n");
            var chars = stringArray.SelectMany(x => x);
            chars.ToList().ForEach(x => Console.Write($"{x} "));


            Console.WriteLine("\n------");
            Console.WriteLine("SelectMany : Print chars : With SQL Like");
            Console.WriteLine("------");
            chars = (from strings in stringArray
                     from charss in strings
                     select charss);
            chars.ToList().ForEach(x => Console.Write($"{x} "));

            Console.WriteLine("------");
            Console.WriteLine("SelectMany : Collection Selector : With Lambda");
            Console.WriteLine("------");
            var studentSubject = CommonHelper.Students
                .SelectMany(x => x.Subjects,
                (student, sub) =>
                new
                {
                    StudentName = student.Name,
                    SubjectName = sub.Title
                });
            studentSubject.ToList().ForEach(x => Console.WriteLine($"{x.StudentName} {x.SubjectName}"));


            Console.WriteLine("\n------");
            Console.WriteLine("SelectMany : Collection Selector : With SQL Like");
            Console.WriteLine("------");
            studentSubject = (from student in CommonHelper.Students
                              from subject in student.Subjects
                              select new
                              {
                                  StudentName = student.Name,
                                  SubjectName = subject.Title
                              });
            studentSubject.ToList().ForEach(x => Console.WriteLine($"{x.StudentName} {x.SubjectName}"));






        }
    }
}
