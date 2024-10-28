using CSharpLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.AccessModifiers
{

    //public class PublicEmployee
    //{
    //    public int Id { get; set; } = 1;
    //    public string Name { get; set; } = "Vedika";
    //    private DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    //    protected double Salary { get; set; } = 120000;
    //    internal string Address { get; set; } = "Raviwar peth";
    //    protected internal string Department { get; set; } = "HR";
    //    private protected int Age { get; set; } = 30;

    //}

    public class PublicEmployeeWithAdditionalDetails : PublicEmployee
    {
        public void ListAllDetails()
        {
            Console.WriteLine($"Id = {Id}"); //as public
            Console.WriteLine($"Name = {Name}");//as public
            //Console.WriteLine($"BirthDate = {BirthDate}");//can't acess as private
            Console.WriteLine($"Salary = {Salary}");//can access as protected
            //Console.WriteLine($"Address = {Address}");//can't access as internal as outside DLL
            Console.WriteLine($"Department = {Department}");//can access as protected internal
            //Console.WriteLine($"Age = {Age}");//can't access as private protected 

        }
    }

    public class EmployeeCheck
    {
        public void ListAllDetails()
        {
            PublicEmployee publicEmployee = new PublicEmployee();

            Console.WriteLine($"Id = {publicEmployee.Id}"); //as public
            Console.WriteLine($"Name = {publicEmployee.Name}");//as public
            //Console.WriteLine($"BirthDate = {BirthDate}");//can't acess as private
            //Console.WriteLine($"Salary = {publicEmployee.Salary}");//can't access as protected
            //Console.WriteLine($"Address = {publicEmployee.Address}");//can access as internal but cant access outside DLL
            //Console.WriteLine($"Department = {publicEmployee.Department}");//can access as internal but cant access outside DLL
            //Console.WriteLine($"Age = {publicEmployee.Age}");//can't access as private protected

        }
    }




    internal class AccessModifier
    {
        public static void AccessModifierExample()
        {
            //All are public members
            PublicEmployee employee = new PublicEmployee();
            employee.Id = 1;
            employee.Name = "Test";

            //private memmbers cant be accessed
            //employee.BirthDate = new DateOnly();

            //protected members cant be accessed
            //employee.Salary = 314345;

            //internal members cant be accessed
            //employee.Address = "";

            //protected internal cant be accessed 
            //employee.Department = "";

            CSharpLibrary.PublicEmployeeWithAdditionalDetails publicEmployeeWithAdditionalDetails = new();
            publicEmployeeWithAdditionalDetails.ListAllDetails();
            //publicEmployeeWithAdditionalDetails.Department = "";//can't access as protected internal
        }

    }


}
