using System;
using System.Collections.Generic;
using System.Text;

namespace LetsCSharp.Polymorphism.MethodOverriding
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual string PrintName() => $"{FirstName} {LastName}";
    }

    public class PartTimeEmployee : Employee
    {
        // will have access to all the props and methods based on access specifiers

        // will always call base class method coz of method hiding 
        // use of NEW is optional, if you dont use it will show warning
        public override string PrintName() => $"Part Time  {FirstName} {LastName}";
    }

    public class FullTimeEmployee : Employee
    {
        // will have access to all the props and methods based on access specifiers

        // will always call base class method coz of method hiding
        public override string PrintName() => $"Full Time  {FirstName} {LastName}";
    }
}
