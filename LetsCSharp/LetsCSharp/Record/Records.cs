using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LetsCSharp.Record
{
    //Record Declaration
    public record class EmployeeRecord(string FirstName, int Age);
    public record class FullTimeEmployeeRecord(string FirstName, int Age, int Hours) : EmployeeRecord(FirstName, Age);

    public record class EmployeeRecordOverrideToString(string FirstName, int Age)
    {
        public override string ToString()
        {
            return $"FirstName is : {FirstName} and Age is : {Age}";
        }
    }

    public record class EmployeeRecordWithMethods(string FirstName, int Age)
    {
        public double CalculateSalary()
        {
            return 1000;
        }
    }


    //Class Declaration
    public class EmployeeClass
    {
        public string FirstName { get; set; }
        public int Age { get; set; }

        public EmployeeClass(string firstName, int age)
        {
            FirstName = firstName;
            Age = age;
        }
    }

    public static class CompareRecordAndClass
    {
        public static void Compare()
        {

            Console.WriteLine("Record type vs Class");
            Console.WriteLine("**********");

            //record instantiation
            EmployeeRecord objR1 = new EmployeeRecord(FirstName: "Vedika", Age: 32);
            EmployeeRecord objR2 = new EmployeeRecord(FirstName: "Vedika", Age: 32);

            //class instantiation
            EmployeeClass objC1 = new EmployeeClass(firstName: "Vedika", age: 32);
            EmployeeClass objC2 = new EmployeeClass(firstName: "Vedika", age: 32);

            Console.WriteLine($"Record printing = {objR1}");
            Console.WriteLine($"Class printing = {objC1}");
            Console.WriteLine("--------------------------------------------");


            Console.WriteLine($"Record JSON serialize = {JsonSerializer.Serialize<EmployeeRecord>(objR1)}");
            Console.WriteLine($"Class JSON serialize = {JsonSerializer.Serialize<EmployeeClass>(objC1)}");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine($"Record equal using == = {objR1 == objR2}");
            Console.WriteLine($"Class equal using == = {objC1 == objC2}");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine($"Record equal using Equals = {Equals(objR1, objR2)}");
            Console.WriteLine($"Class equal using Equals = {Equals(objC1, objC2)}");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine($"Record equal using ReferenceEquals = {ReferenceEquals(objR1, objR2)}");
            Console.WriteLine($"Class equal using ReferenceEquals = {ReferenceEquals(objC1, objC2)}");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine($"Record HashCode R1: {objR1.GetHashCode()} R2: {objR2.GetHashCode()}");
            Console.WriteLine($"Class HashCode C1: {objC1.GetHashCode()} C2: {objC2.GetHashCode()}");
            Console.WriteLine("--------------------------------------------");


            //NonDestructive Mutation
            EmployeeRecord objR3 = objR1 with
            {
                Age = 30
            };
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("NonDestructive Mutation");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Record printing = {objR1}");
            Console.WriteLine($"Record printing = {objR3}");


            //Deconstruct
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Deconstruct Mutation");
            Console.WriteLine("--------------------------------------------");
            var (name, age) = objR1;
            Console.WriteLine($"Name: {name}  Age: {age}");

            //Inheritance
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Inheritance Mutation");
            Console.WriteLine("--------------------------------------------");
            FullTimeEmployeeRecord fullTimeEmployeeRecord = new("nidhi", 25, 7);
            Console.WriteLine($"FullTimeEmployeeRecord : {fullTimeEmployeeRecord}");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("override ToString");
            Console.WriteLine("--------------------------------------------");
            EmployeeRecordOverrideToString employeeRecordOverrideToString = new("Nidhi", 25);
            Console.WriteLine($"EmployeeRecordOverrideToString : {employeeRecordOverrideToString}");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("override ToString");
            Console.WriteLine("--------------------------------------------");
            EmployeeRecordWithMethods employeeRecordWithMethods = new("Nidhi", 25);
            Console.WriteLine($"EmployeeRecordOverrideToString : {employeeRecordWithMethods} and salary : {employeeRecordWithMethods.CalculateSalary()}");

        }
    }
}
