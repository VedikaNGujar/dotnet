using LetsCSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{
    internal static class Joins
    {
        public static void Test()
        {

            Console.WriteLine("---Joins---");
            CommonHelper.InitializeData();

            Console.WriteLine("------");
            Console.WriteLine("Group Join : With Lambda");
            Console.WriteLine("------");

            var groupJoin = CommonHelper.Departments.GroupJoin(
                CommonHelper.Employees,
                d => d.Id,
                e => e.Department.Id,
                (dep, emp) => new
                {
                    Department = dep,
                    Employees = emp
                });

            foreach (var dep in groupJoin)
            {
                Console.WriteLine("---Department---");
                Console.WriteLine($"---Id: {dep.Department.Id} Name: {dep.Department.Name}");
                Console.WriteLine("---Employees---");
                foreach (var emp in dep.Employees)
                {
                    Console.WriteLine($"ID : {emp.Id} Name: {emp.Name}");
                }
            }

            Console.WriteLine("------");
            Console.WriteLine("Group Join : With Sql Like");
            Console.WriteLine("------");

            groupJoin = (from dept in CommonHelper.Departments
                         join emp in CommonHelper.Employees
                         on dept.Id equals emp.Department.Id into eGroup
                         select new { Department = dept, Employees = eGroup });

            foreach (var dep in groupJoin)
            {
                Console.WriteLine("---Department---");
                Console.WriteLine($"---Id: {dep.Department.Id} Name: {dep.Department.Name}");
                Console.WriteLine("---Employees---");
                foreach (var emp in dep.Employees)
                {
                    Console.WriteLine($"ID : {emp.Id} Name: {emp.Name}");
                }
            }

            ///--- Group join return heirarch where as join return flat
            ///join returns only matching data, whereas group join returns all
            Console.WriteLine("Join : With Lambda");
            Console.WriteLine("------");

            var joins = CommonHelper.Departments.Join(
                CommonHelper.Employees,
                d => d.Id,
                e => e.Department.Id,
                (dep, emp) => new
                {
                    Department = dep,
                    Employees = emp
                });

            foreach (var data in joins)
            {
                Console.WriteLine("---Department---");
                Console.WriteLine($"---Id: {data.Department.Id} Name: {data.Department.Name}");
                Console.WriteLine("---Employees---");
                Console.WriteLine($"---Id: {data.Employees.Id} Name: {data.Employees.Name}");
            }

            Console.WriteLine("------");
            Console.WriteLine("Join : With Sql Like");
            Console.WriteLine("------");

            joins = (from dept in CommonHelper.Departments
                     join emp in CommonHelper.Employees
                     on dept.Id equals emp.Department.Id
                     select new { Department = dept, Employees = emp });

            foreach (var data in joins)
            {
                Console.WriteLine("---Department---");
                Console.WriteLine($"---Id: {data.Department.Id} Name: {data.Department.Name}");
                Console.WriteLine("---Employees---");
                Console.WriteLine($"---Id: {data.Employees.Id} Name: {data.Employees.Name}");
            }

            ///--- Group join return heirarch where as join return flat
            ///join returns only matching data, whereas group join returns all
            Console.WriteLine("Left Join : With Lambda");
            Console.WriteLine("------");

            var ljoins = CommonHelper.Departments.GroupJoin(
                CommonHelper.Employees,
                d => d.Id,
                e => e.Department.Id,
                (dep, emp) => new
                {
                    Department = dep,
                    Employees = emp
                })
                .SelectMany(x => x.Employees.DefaultIfEmpty(), (dept, emp) => new
                {
                    Department = dept.Department.Name,
                    Employee = emp?.Name ?? "No Employee"
                });

            foreach (var data in ljoins)
            {
                Console.WriteLine($"Dept Name: {data.Department} Employee Name: {data.Employee}");
            }

            Console.WriteLine("------");
            Console.WriteLine("Left Join : With Sql Like");
            Console.WriteLine("------");

            ljoins = (from dept in CommonHelper.Departments
                      join emp in CommonHelper.Employees
                      on dept.Id equals emp.Department.Id into eg
                      from empGroup in eg.DefaultIfEmpty()
                      select new
                      {
                          Department = dept.Name,
                          Employee = empGroup?.Name ?? "No Employee"
                      });

            foreach (var data in ljoins)
            {
                Console.WriteLine($"Dept Name: {data.Department} Employee Name: {data.Employee}");

            }
        }
    }
}
