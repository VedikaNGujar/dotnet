using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.PropertiesExample
{
    public class EmployeeProperty
    {
        private string _name; // field
        public string Name //property
        {
            get { return _name; }
            set { _name = value; }
        }

        public string NamePrivateSet { get; private set; } //property
        public string NamePrivateGet { private get; set; } //property

        //protected
        public string NameProtectedSet { get; protected set; } //property with protected only in derived class allowed
        public string NameProtectedGet { protected get; set; } //property with protected only in derived class allowed

        public void SetPrivatePropertyMembers()
        {
            NamePrivateSet = "Nidhi";//allowed
            NamePrivateGet = "Nidhi";
            Console.WriteLine($"{NamePrivateGet}");//allowed here
        }

        public string NameWithNoSet { get { return _name; } } //property  
        public string NameWithNoGet { set { _name = value; } } //property

        public string NameWithOnlyGet { get; }//property  but we can set this is constructore

        public string NameWithAutoPropertyInitialisation { get; set; } = "Vedika";// this can be helpful 
                                                                                  //if no constructor

        //Init
        //When init is used it restricts property to be set only once.
        ///after the object is created it becomes immutable
        public string NameWithInit { get; init; } = "Vedika";
        public void SetNameWithInit()
        {
            //this.NameWithInit = "Nidhi"; // error
        }

        public EmployeeProperty()
        {

            NameWithOnlyGet = "Hey"; //only in constructor
            //NameWithNoSet= "Hey";//will give error

            NameWithInit = "Nidhi"; // allowed here
        }
    }

    public class EmployeeDerviedProperty : EmployeeProperty
    {
        public void SetPrivatePropertyMembersDervied()
        {
            //NamePrivateSet = "Nidhi";// not allowed
            //Console.WriteLine($"{NamePrivateGet}");//not allowed here
            //but protected allowed
            NameProtectedSet = "Nidhi";// not allowed
            Console.WriteLine($"{NameProtectedGet}");//not allowed here
        }
    }


    public class SaleItemProperty
    {
        string _name;
        decimal _cost;

        public SaleItemProperty(string name, decimal cost)
        {
            _name = name;
            _cost = cost;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _cost;
            set => _cost = value;
        }
    }

    public static class PropertyExample
    {
        public static void Execute()
        {
            EmployeeProperty employeeProperty = new EmployeeProperty();
            employeeProperty.Name = "Vedika";
            Console.WriteLine(employeeProperty.Name);

            //employeeProperty.NamePrivateSet = "Nidhi"; // will give error
            //employeeProperty.NameProtectedSet = "Nidhi"; // will give error
            employeeProperty.NamePrivateGet = "Nidhi";
            //Console.WriteLine($"{employeeProperty.NamePrivateGet}");// will give error
            //Console.WriteLine($"{employeeProperty.NameProtectedGet}");// will give error

            //employeeProperty.NameWithNoSet= employeeProperty.Name;//error as it readonly
            //Console.WriteLine(employeeProperty.NameWithNoGet);// error as it write only

            //employeeProperty.NameWithInit = "Nidhi";//error
            EmployeeProperty employeeProperty1 = new EmployeeProperty()
            {
                NameWithInit = "Hey",
            }; //allowed during object initialiser;
            //employeeProperty1.NameWithInit = "hey1";//error


        }
    }
}
