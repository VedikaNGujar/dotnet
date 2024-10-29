// See https://aka.ms/new-console-template for more information

using CSharp;
using LetsCSharp.Abstract;
using LetsCSharp.AccessModifiers;
using LetsCSharp.Comparison;
using LetsCSharp.Delegates;
using LetsCSharp.Enums;
using LetsCSharp.Generics;
using LetsCSharp.Indexer;
using LetsCSharp.Interface;
using LetsCSharp.IsAndAsExample;
using LetsCSharp.List;
using LetsCSharp.PropertiesExample;
using LetsCSharp.Record;
using LetsCSharp.ShallowDeepCopy;
using LetsCSharp.Throw;
using LetsCSharp.TyepCasting_Conversion_Parsing;
using static LetsCSharp.ShallowDeepCopy.ShallowDeepCopy;

internal class Program
{
    private static void Main(string[] args)
    {
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
        //CSharp.Polymorphism.MethodHiding.Employee employee
        //    = new CSharp.Polymorphism.MethodHiding.Employee()
        //    //will always call base class method
        //    {
        //        FirstName = "FirstName",
        //        LastName = "LastName"
        //    };
        //Helper.WriteLineWithTab(employee.PrintName());

        //CSharp.Polymorphism.MethodHiding.PartTimeEmployee employee4
        //   = new CSharp.Polymorphism.MethodHiding.PartTimeEmployee()
        //   //will always call PartTimeEmployee class method
        //   {
        //       FirstName = "FirstName",
        //       LastName = "LastName"
        //   };
        //Helper.WriteLineWithTab(employee4.PrintName());

        //CSharp.Polymorphism.MethodHiding.PartTimeEmployee employee5
        //  = new CSharp.Polymorphism.MethodHiding.PartTimeEmployee()
        //  //will always call Employee class method
        //  {
        //      FirstName = "FirstName",
        //      LastName = "LastName"
        //  };
        ////typecasting
        //Helper.WriteLineWithTab(
        //    ((CSharp.Polymorphism.MethodHiding.Employee)employee5).PrintName());

        //CSharp.Polymorphism.MethodHiding.Employee employee1
        //    = new CSharp.Polymorphism.MethodHiding.PartTimeEmployee()
        //    //will always call base class method
        //    {
        //        FirstName = "FirstName",
        //        LastName = "LastName"
        //    };
        //Helper.WriteLineWithTab(employee1.PrintName());

        //CSharp.Polymorphism.MethodHiding.Employee employee2
        //    = new CSharp.Polymorphism.MethodHiding.FullTimeEmployee()
        //    //will always call base class method
        //    {
        //        FirstName = "FirstName",
        //        LastName = "LastName"
        //    };
        //Helper.WriteLineWithTab(employee2.PrintName());
        ////typecasting
        //Helper.WriteLineWithTab(
        //    ((CSharp.Polymorphism.MethodHiding.FullTimeEmployee)employee2).PrintName());




        //Interfaces();
        //Abstracts();
        //Delegates();
        //Generics();
        //Indexers();
        //Comparisions();
        //ShallowDeepCopyCheck();
        ThrowCheck();
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