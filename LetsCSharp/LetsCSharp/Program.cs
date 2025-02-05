﻿// See https://aka.ms/new-console-template for more information

using CSharp;
using LetsCSharp.Abstract;
using LetsCSharp.AccessModifiers;
using LetsCSharp.AsyncAwait;
using LetsCSharp.CloneAndCopy;
using LetsCSharp.Comparison;
using LetsCSharp.Constructors;
using LetsCSharp.Delegates;
using LetsCSharp.Enums;
using LetsCSharp.EqualityComparer;
using LetsCSharp.Generics;
using LetsCSharp.Indexer;
using LetsCSharp.Interface;
using LetsCSharp.IsAndAsExample;
using LetsCSharp.LinQ;
using LetsCSharp.List;
using LetsCSharp.NameOf;
using LetsCSharp.Params;
//using LetsCSharp.Polymorphism.MethodHiding;
using LetsCSharp.Polymorphism.MethodOverloading;
using LetsCSharp.PropertiesExample;
using LetsCSharp.Record;
using LetsCSharp.ShallowDeepCopy;
using LetsCSharp.Struct;
using LetsCSharp.Throw;
using LetsCSharp.TyepCasting_Conversion_Parsing;
using static LetsCSharp.ShallowDeepCopy.ShallowDeepCopy;

internal class Program
{
    record Point(int X, int Y);
    private static void Main(string[] args)
    {

        //var original = new Point(1, 2);
        //var shifted = original with { X = original.X + 3, Y = original.Y - 1 };
        //Console.WriteLine(shifted);

        //CompareRecordAndClass.Compare();
        //EnumsExample.PrintEnums();
        //EnumsExample.PrintEnumsMembers();
        //PropertyExample.Execute();
        //IsAndAs.CheckIsKeyword();
        //IsAndAs.CheckAsKeyword();
        //TyepCasting_Conversion_ParsingExample.TypeConversion();
        //TypeCasting_Conversion_ParsingExample.TypeCasting();
        //TypeCasting_Conversion_Parsing.ParseAndTryParse();
        //AccessModifier.AccessModifierExample();



        //List.ListTest();
        //Helper.WriteLine("/**Constructors**/");
        //Example example = new Example();// will call default constructor
        //Example example1 = new Example(1);// will call paramterised constructor

        //Helper.WriteLine("/**Static Constructors**/");
        //StaticExample staticExample = new StaticExample();// will call default constructor
        //StaticExample staticExample1 = new StaticExample(1);// will call paramterised constructor

        //Helper.WriteLine("/**Error Constructors**/");
        ////ErrorExample errorExample = new ErrorExample();// will THROW error as there is no default constructor
        //ErrorExample errorExample1 = new ErrorExample(1);// will call paramterised constructor

        //Helper.WriteLine("/**Polymorphism**/");
        //Helper.WriteLine("/****Method Hiding****/");
        //Employee employee = new Employee()
        ////will always call base class method
        //{
        //    FirstName = "FirstName",
        //    LastName = "LastName"
        //};
        //Helper.WriteLineWithTab(employee.PrintName());

        //PartTimeEmployee employee4 = new PartTimeEmployee()
        ////will always call PartTimeEmployee class method
        //{
        //    FirstName = "FirstName",
        //    LastName = "LastName"
        //};
        //Helper.WriteLineWithTab(employee4.PrintName());

        //PartTimeEmployee employee5 = new PartTimeEmployee()
        ////will always call Employee class method
        //{
        //    FirstName = "FirstName",
        //    LastName = "LastName"
        //};
        ////typecasting
        //Helper.WriteLineWithTab(((Employee)employee5).PrintName());

        //Employee employee1 = new PartTimeEmployee()
        ////will always call base class method
        //{
        //    FirstName = "FirstName",
        //    LastName = "LastName"
        //};
        //Helper.WriteLineWithTab(employee1.PrintName());

        //Employee employee2 = new FullTimeEmployee()
        ////will always call base class method
        //{
        //    FirstName = "FirstName",
        //    LastName = "LastName"
        //};
        //Helper.WriteLineWithTab(employee2.PrintName());
        ////typecasting
        //Helper.WriteLineWithTab(((FullTimeEmployee)employee2).PrintName());


        Helper.WriteLine("/**Polymorphism**/");
        Helper.WriteLine("/****Method Overloading****/");
        Employee employee = new Employee()
        //will always call base class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee.PrintName());

        PartTimeEmployee employee4 = new PartTimeEmployee()
        //will always call PartTimeEmployee class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee4.PrintName());

        PartTimeEmployee employee5 = new PartTimeEmployee()
        //will always call PartTimeEmployee class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        //typecasting
        Helper.WriteLineWithTab(((Employee)employee5).PrintName());

        Employee employee1 = new PartTimeEmployee()
        //will call PartTime class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee1.PrintName());

        Employee employee2 = new FullTimeEmployee()
        //will call FullTime class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee2.PrintName());
        //typecasting
        Helper.WriteLineWithTab(((FullTimeEmployee)employee2).PrintName());




        //Interfaces();
        //Abstracts();
        // Delegates();
        //Generics();
        //Indexers();
        //Comparisions();
        //ShallowDeepCopyCheck();
        //ThrowCheck();
        //CloneAndCopyCheck();
        //GenericDelegateCheck();
        //LinqTest();
        //EqualityComparerTest();
        //AsyncAwaitTest();
        //NameOfTest();
        //StructTest();
        //ParamsTest();
    }

    private static void ParamsTest()
    {
        Console.WriteLine(ParamsExample.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        Console.WriteLine(ParamsExample.Add()); // this will call Add which has only params.
        Console.WriteLine(ParamsExample.Add(10));
        Console.WriteLine(ParamsExample.Add(10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        Console.WriteLine(ParamsExample.ConcatString("Vedika", "Nidhi", "Gujar"));
    }

    private static void StructTest()
    {
        var bar = new Bar { foo = new Foo() };
        bar.foo.Change(5);
        Console.Write(bar.foo.Value);
    }

    private static void NameOfTest()
    {
        NameOf.Test();
    }

    private static void AsyncAwaitTest()
    {
        AsyncAwait.Test();
    }

    private static void EqualityComparerTest()
    {
        EqualityComparerCheck.Test();
    }

    private static void LinqTest()
    {
        //Aggregate.Test();
        //Restriction.Test();
        //Projection.Test();
        //Ordering.Test();
        //Partitioning.Test();
        //DictionaryAndLookupAndGroupBy.Test();
        //CastAndOfType.Test();
        //ElementsOperator.Test();
        Joins.Test();

    }

    private static void GenericDelegateCheck()
    {
        PredicateTest p = new PredicateTest();
        p.CheckPredicate();

        ActionTest a = new ActionTest();
        a.CheckAction();

        FunctionTest f = new FunctionTest();
        f.CheckFunction();
    }

    private static void CloneAndCopyCheck()
    {
        CloneAndCopy c = new CloneAndCopy();
        c.Test();
    }

    private static void ThrowCheck()
    {
        Throw t = new Throw();
        t.TestThrow();
        t.TestThrowEx();
    }

    private static void ShallowDeepCopyCheck()
    {
        StudentShallowDeepCheck s = new StudentShallowDeepCheck();
        s.Test();
    }

    private static void Comparisions()
    {
        CustomerComparisionTest customerComparisionTest = new CustomerComparisionTest();
        customerComparisionTest.Test();
    }

    private static void Indexers()
    {
        IndexerTest indexerTest = new IndexerTest();
        indexerTest.Test();
    }

    private static void Generics()
    {
        Console.WriteLine(Generic.AreEqual(10, 20));
        Console.WriteLine(Generic.AreEqual(20, 20));

        GenericExample ge = new();
        ge.Test();
    }

    private static void Delegates()
    {
        DelegateEx d = new DelegateEx();
        //d.TestDelegate();
        d.TestDelegateMulticast();

        Covariance c = new Covariance();
        c.Test();

        Contravariance c1 = new Contravariance();
        c1.Test();
    }

    private static void Abstracts()
    {
        //Abstract o = new Abstract();//error we cannot create instance of abstract
    }

    private static void Interfaces()
    {
        ClassInterface1 classInterface1 = new ClassInterface1();
        classInterface1.GetName();

        I1 i1 = new ClassInterface1();
        i1.GetName();
        I2 i2 = new ClassInterface1();
        i2.GetName();



        i1 = new ClassInterfaceExplicit();
        i1.GetName();
        i2 = new ClassInterfaceExplicit();
        i2.GetName();
        var classInterfaceExplicit = new ClassInterfaceExplicit();
        classInterfaceExplicit.GetName();


        i1 = new ClassInterfaceExplicit1();
        i1.GetName();
        i2 = new ClassInterfaceExplicit1();
        i2.GetName();
        var classInterfaceExplicit1 = new ClassInterfaceExplicit1();
        //classInterfaceExplicit1.GetName(); // this will give error


    }
}