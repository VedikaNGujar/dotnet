using System.Net;
using System.Xml.Linq;

namespace CSharpLibrary
{

    internal class InternalEmployee //this class cannot be access outside the assembly
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Vedika";
        private DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        protected double Salary { get; set; } = 120000;
        internal string Address { get; set; } = "Raviwar peth";
    }
    //public class InternalEmployeeWithAdditionalDetails : InternalEmployee //will throw error 
    //{ 
    //}


    public class PublicEmployee
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Vedika";
        private DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        protected double Salary { get; set; } = 120000;
        internal string Address { get; set; } = "Raviwar peth";
        protected internal string Department { get; set; } = "HR";
        private protected int Age { get; set; } = 30;

    }

    public class PublicEmployeeWithAdditionalDetails : PublicEmployee
    {
        public void ListAllDetails()
        {
            Console.WriteLine($"Id = {Id}"); //as public
            Console.WriteLine($"Name = {Name}");//as public
            //Console.WriteLine($"BirthDate = {BirthDate}");//can't acess as private
            Console.WriteLine($"Salary = {Salary}");//can access as protected
            Console.WriteLine($"Address = {Address}");//can access as internal but cant access outside DLL
            Console.WriteLine($"Department = {Department}");//can access as internal but cant access outside DLL
            Console.WriteLine($"Age = {Age}");//can access as internal but cant access outside DLL

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
            Console.WriteLine($"Address = {publicEmployee.Address}");//can access as internal but cant access outside DLL
            Console.WriteLine($"Department = {publicEmployee.Department}");//can access as internal but cant access outside DLL
            //Console.WriteLine($"Age = {publicEmployee.Age}");//can't access as private protected

        }
    }


}