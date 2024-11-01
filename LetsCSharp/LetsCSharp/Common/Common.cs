using LetsCSharp.LinQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Common
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
    }



    public class Subject
    {
        public string Title { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Fees { get; set; }
        public int GiftMoney { get; set; }
        public List<Subject> Subjects { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Gender: {Gender} Fees: {Fees}";
        }
    }

    public static class CommonHelper
    {
        public static List<Student> Students { get; set; }
           = new List<Student>();

        //public static List<Department> Departments { get; set; }
        //   = new List<Department>();


        public static List<Employee> Employees { get; set; }
           = new List<Employee>();


        public static void InitializeData()
        {
            Students.Add(new Student()
            {
                GiftMoney = 1000,
                Gender = "Female",
                Id = 1,
                Name = "Vedika Gujar",
                Fees = 1000,
                Subjects = new() { new() { Title = "Maths" }, new() { Title = "Science" }, new() { Title = "English" } }
            });
            Students.Add(new Student()
            {
                GiftMoney = 1000,
                Gender = "Female",
                Id = 1,
                Name = "Vedika1 Gujar1",
                Fees = 1000,
                Subjects = new() { new() { Title = "Maths" }, new() { Title = "Science" }, new() { Title = "English" } }
            });
            Students.Add(new Student()
            {
                GiftMoney = 2000,
                Gender = "Female",
                Id = 2,
                Name = "Nidhi Gujar",
                Fees = 2000,
                Subjects = new() { new() { Title = "Science" }, new() { Title = "English" } }

            });
            Students.Add(new Student()
            {
                GiftMoney = 2000,
                Gender = "Female",
                Id = 22,
                Name = "Nidhi Gujar",
                Fees = 3000,
                Subjects = new() { new() { Title = "Science" }, new() { Title = "English" } }

            });
            Students.Add(new Student()
            {
                GiftMoney = 200,
                Gender = "Female",
                Id = 3,
                Name = "Pankaja Gujar",
                Fees = 4000,
                Subjects = new() { new() { Title = "Social Science" }, new() { Title = "English" } }

            });
            Students.Add(new Student()
            {
                GiftMoney = 400,
                Gender = "Male",
                Id = 4,
                Name = "Nandkumar Gujar",
                Fees = 500,
                Subjects = new() { new() { Title = "Social Science" }, new() { Title = "English" } }

            });

            Department department1 = new() { Id = 1, Name = "Computer Science" };
            Department department2 = new() { Id = 2, Name = "HR" };
            Department department3 = new() { Id = 2, Name = "Accounts" };


            Employees.AddRange(
                new List<Employee>() {
                    new Employee
                    {
                        Id = 1,
                        Name ="Vedika Gujar",
                        Department = department1
                    },
                new Employee
                    {
                        Id = 2,
                        Name ="Nidhi Gujar",
                        Department = department1
                    },
                new Employee
                    {
                        Id = 3,
                        Name ="Neha Kulkarni",
                        Department = department2
                    }});


        }
    }
}
