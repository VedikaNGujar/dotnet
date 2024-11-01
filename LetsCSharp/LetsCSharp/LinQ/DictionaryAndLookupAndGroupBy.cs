using LetsCSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{

    internal static class DictionaryAndLookupAndGroupBy
    {


        public static void Test()
        {
            Console.WriteLine("---Dictionary And Lookup and Group by---");
            CommonHelper.InitializeData();

            Console.WriteLine("------");
            Console.WriteLine("To Dictionary");
            Console.WriteLine("------");
            //var resultStudentName = CommonHelper.Students.ToDictionary(x => x.Id); //Dictionary cannot have identical Ids
            var studentDictionary = CommonHelper.Students.ToDictionary(x => new { x.Id, x.Name });
            studentDictionary.ToList().ForEach(x => Console.WriteLine($"Key: Id: {x.Key.Id} Name: {x.Key.Name} Student: {x.Value.ToString()} "));

            Console.WriteLine("------");
            Console.WriteLine("To Lookup");
            Console.WriteLine("------");
            var studentLookup = CommonHelper.Students.ToLookup(x => x.Id); //Lookups can have identical Ids
            //studentLookup.ToList().ForEach(x => Console.WriteLine($"Key: Id: {x.Key} Student: {x.ToList().ForEach(y => Console.WriteLine(y.ToString()))}"));
            foreach (var student in studentLookup)
            {
                Console.WriteLine($"Key: Id: {student.Key}");
                Console.WriteLine("------");
                Console.WriteLine($"Students");
                Console.WriteLine("------");
                foreach (var students in student)
                {
                    Console.WriteLine(students.ToString());
                }
            }

            //difference between lookup and group by is lookup is immediate execution,
            //where as group by is deffered
            Console.WriteLine("------");
            Console.WriteLine("GroupBy - by Lambda");
            Console.WriteLine("------");
            var studentGroupBy = CommonHelper.Students.GroupBy(x => x.Id); //Lookups can have identical Ids
            foreach (var student in studentGroupBy)
            {
                Console.WriteLine($"Key: Id: {student.Key}");
                Console.WriteLine("------");
                Console.WriteLine($"Students");
                Console.WriteLine("------");
                foreach (var students in student)
                {
                    Console.WriteLine(students.ToString());
                }
            }

            Console.WriteLine("------");
            Console.WriteLine("GroupBy - by SQL Like");
            Console.WriteLine("------");
            studentGroupBy = (from students in CommonHelper.Students
                              group students by students.Id into studgroup
                              orderby studgroup.Key
                              select studgroup);
            foreach (var student in studentGroupBy)
            {
                Console.WriteLine($"Key: Id: {student.Key}");
                Console.WriteLine("------");
                Console.WriteLine($"Students");
                Console.WriteLine("------");
                foreach (var students in student)
                {
                    Console.WriteLine(students.ToString());
                }
            }

            Console.WriteLine("------");
            Console.WriteLine("GroupBy - by SQL Like - by new key");
            Console.WriteLine("------");
            var newStudentGroupBy = (from students in CommonHelper.Students
                                     group students by new { students.Id, students.Name } into studgroup
                                     orderby studgroup.Key.Id
                                     select studgroup);
            foreach (var student in newStudentGroupBy)
            {
                Console.WriteLine($"Key: Id: {student.Key.Id}");
                Console.WriteLine($"Key: Name: {student.Key.Name}");
                Console.WriteLine("------");
                Console.WriteLine($"Students");
                Console.WriteLine("------");
                foreach (var students in student)
                {
                    Console.WriteLine(students.ToString());
                }
            }




        }
    }
}
