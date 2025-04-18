﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Interface
{
    internal interface Iinterface
    {
        //public int j = 0;// not allowed

        public int i //getter setter are allowed
        {
            get;
            set;
        }
    }

    internal class ClassInterface : Iinterface
    {
        public int i
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }



    internal interface InterfaceWithDefinition
    {
        public string GetName();

        public string GetSalary() { return ""; } //allowed after c# 8.0
        public string GetSalaryVersion2()
        {
            Console.WriteLine("Salary  v2 is");
            return "Salary v2 is";
        } //allowed after c# 8.0
    }

    public class ClassInterfaceWithDefinition : InterfaceWithDefinition
    {
        public string GetName()
        {
            Console.WriteLine("Name");
            return "Name";
        }
        public string GetSalary()
        {
            Console.WriteLine("Salary is");
            return "Salary is";
        }
    }


    internal interface I1
    {
        public string GetName();
        public string GetSalary() { return ""; } //allowed after c# 8.0
    }

    internal interface I2
    {
        public string GetName();
    }

    public class ClassInterface1 : I1, I2
    {
        public string GetName()
        {
            Console.WriteLine("Getname called");
            return "Getname called";
        }
    }

    public class ClassInterfaceExplicit : I1, I2
    {
        string I1.GetName() //this will throw error if added access modifier
        {
            Console.WriteLine("I1 Getname called");
            return "Getname called";
        }

        public string GetName()
        {
            Console.WriteLine("I2 Getname called");
            return "Getname called";
        }

    }

    public class ClassInterfaceExplicit1 : I1, I2
    {
        string I1.GetName()
        {
            Console.WriteLine("I1 Getname called");
            return "Getname called";

        }

        string I2.GetName()
        {
            Console.WriteLine("I2 Getname called");
            return "Getname called";
        }
    }
}
