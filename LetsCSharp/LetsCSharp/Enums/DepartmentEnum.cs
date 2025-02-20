using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Enums
{
    public enum DepartmentEnum
    {
        IT,
        Finance,
        Sales,
        HR,
        Marketing
    }

    public enum DepartmentEnumWithNumbers
    {
        IT,
        Finance = 5,
        Sales, //will be 6
        HR, //will be 7
        Marketing //will be 8
    }

    public enum DepartmentEnumFromByte : byte //underlying type as byte, by default it is Int32, can be
                                              //sbyte, short,ushort,int,uint,long or ulong
    {
        Unknown = 0,
        IT = 25,
        Finance = 30,
        Sales = 35,
        HR = 90,
        Marketing
    }

    public static class EnumsExample
    {
        public static void PrintEnums()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" {DepartmentEnum.IT} ");
            Console.WriteLine($" {DepartmentEnum.Finance} ");
            Console.WriteLine($" {DepartmentEnum.Sales} ");
            Console.WriteLine($" {DepartmentEnum.HR} ");
            Console.WriteLine($" {DepartmentEnum.Marketing} ");


            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("With Numbers");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" {(int)DepartmentEnumWithNumbers.IT} ");
            Console.WriteLine($" {(int)DepartmentEnumWithNumbers.Finance} ");
            Console.WriteLine($" {(int)DepartmentEnumWithNumbers.Sales} ");
            Console.WriteLine($" {(int)DepartmentEnumWithNumbers.HR} ");
            Console.WriteLine($" {(int)DepartmentEnumWithNumbers.Marketing} ");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("underline storage will be byte");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" {(int)DepartmentEnumFromByte.IT} ");
            Console.WriteLine($" {(int)DepartmentEnumFromByte.Finance} ");
            Console.WriteLine($" {(int)DepartmentEnumFromByte.Sales} ");
            Console.WriteLine($" {(int)DepartmentEnumFromByte.HR} ");
            Console.WriteLine($" {(int)DepartmentEnumFromByte.Marketing} ");

        }

        public static void PrintEnumsMembers()
        {
            Console.WriteLine("Enum using GetNames");
            foreach (string str in Enum.GetNames(typeof(DepartmentEnum)))
                Console.WriteLine($"{str}");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Enum using GetName at position");
            Console.WriteLine($" Name of constant that has value 4 {Enum.GetName(typeof(DepartmentEnum), 4)} ");
            Console.WriteLine($" Name of constant that has value 5 (No value so will not print anything) {Enum.GetName(typeof(DepartmentEnum), 5)} ");


            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Checking Enum member exists using Enum IsDefined()");
            Console.WriteLine($" IsDefined enum that has value 4 {Enum.IsDefined(typeof(DepartmentEnum), 4)} ");
            Console.WriteLine($" IsDefined enum that has value 5 {Enum.IsDefined(typeof(DepartmentEnum), 5)} ");

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Get Type and underlying type");
            Console.WriteLine("--------------------------------------------");
            Enum[] values = { DepartmentEnum.Sales, DepartmentEnumWithNumbers.Sales, DepartmentEnumFromByte.Sales };
            foreach (var value in values)
                DisplayType(value);

        }

        private static void DisplayType(Enum value)
        {
            Type type = value.GetType();
            Console.WriteLine($"Type:  {type.Name}");
            Type utype = Enum.GetUnderlyingType(type);
            Console.WriteLine($"Type:  {utype.Name}");
            Console.WriteLine("--------------------------------------------");

        }
    }
}
