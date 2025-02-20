// See https://aka.ms/new-console-template for more information

using CSharp;
using LetsCSharp.Abstract;
using LetsCSharp.AccessModifiers;
using LetsCSharp.AsyncAwait;
using LetsCSharp.CloneAndCopy;
using LetsCSharp.Comparison;
using LetsCSharp.Constant;
using LetsCSharp.Constructors;
using LetsCSharp.Delegates;
using LetsCSharp.Disposable;
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
using LetsCSharp.Polymorphism.MethodHiding;
using LetsCSharp.Polymorphism.MethodOverriding;
using LetsCSharp.PropertiesExample;
using LetsCSharp.ReadOnly;
using LetsCSharp.Record;
using LetsCSharp.ShallowDeepCopy;
//using LetsCSharp.Static;
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


        //Constructors();
        //MethodOverloading();
        //MethodHiding();
        //Interfaces();
        //Abstracts();
        //Static();
        //ReadonlyExample();
        ConstantExample();
        //Delegates();
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

        //Disposable();
    }

    private static void ConstantExample()
    {
        Constant c = new Constant(10);
    }

    private static void ReadonlyExample()
    {
        Readonly r = new Readonly();
        ReadonlyRefCheck rd = new ReadonlyRefCheck();
    }

    private static void Static()
    {
        //StaticExample staticExample = new StaticExample();//error
        LetsCSharp.Static.StaticExample.i = 30;
        LetsCSharp.Static.StaticExample.j = 20;
        LetsCSharp.Static.StaticExample.GetName();


    }

    private static void Constructors()
    {
        Helper.WriteLine("/**Constructors**/");
        Example example = new Example();// will call default constructor
        Example example1 = new Example(1);// will call paramterised constructor

        Helper.WriteLine("/**Static Constructors**/");
        StaticExample staticExample = new StaticExample();// will call default constructor
        StaticExample staticExample1 = new StaticExample(1);// will call paramterised constructor

        Helper.WriteLine("/**Private Constructors**/");
        //ErrorExample1 errorExample1 = new ErrorExample1(); //will throw error as its constructor is private

        Helper.WriteLine("/**Error Constructors**/");
        //ErrorExample errorExample = new ErrorExample();// will THROW error as there is no default constructor
        ErrorExample errorExample1 = new ErrorExample(1);// will call paramterised constructor
    }

    private static void MethodHiding()
    {
        Helper.WriteLine("/**Polymorphism**/");
        Helper.WriteLine("/****Method Hiding****/");
        LetsCSharp.Polymorphism.MethodHiding.Employee employee =
            new LetsCSharp.Polymorphism.MethodHiding.Employee()
            //will always call base class method
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
        Helper.WriteLineWithTab(employee.PrintName());

        LetsCSharp.Polymorphism.MethodHiding.PartTimeEmployee employee4 =
            new LetsCSharp.Polymorphism.MethodHiding.PartTimeEmployee()
            //will always call PartTimeEmployee class method
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
        Helper.WriteLineWithTab(employee4.PrintName());

        LetsCSharp.Polymorphism.MethodHiding.PartTimeEmployee employee5 =
            new LetsCSharp.Polymorphism.MethodHiding.PartTimeEmployee()
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
        //typecasting will always call Employee class method
        Helper.WriteLineWithTab(((LetsCSharp.Polymorphism.MethodHiding.Employee)employee5).PrintName());

        LetsCSharp.Polymorphism.MethodHiding.Employee employee1 =
            new LetsCSharp.Polymorphism.MethodHiding.PartTimeEmployee()
            //will always call base class method
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
        Helper.WriteLineWithTab(employee1.PrintName());

        LetsCSharp.Polymorphism.MethodHiding.Employee employee2 =
            new LetsCSharp.Polymorphism.MethodHiding.FullTimeEmployee()
            //will always call base class method
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
        Helper.WriteLineWithTab(employee2.PrintName());
        //typecasting
        Helper.WriteLineWithTab(((LetsCSharp.Polymorphism.MethodHiding.FullTimeEmployee)employee2).PrintName());
    }

    private static void MethodOverloading()
    {
        Helper.WriteLine("/**Polymorphism**/");
        Helper.WriteLine("/****Method Overloading****/");
        LetsCSharp.Polymorphism.MethodOverriding.Employee employee = new LetsCSharp.Polymorphism.MethodOverriding.Employee()
        //will always call base class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee.PrintName());

        LetsCSharp.Polymorphism.MethodOverriding.PartTimeEmployee employee4 = new LetsCSharp.Polymorphism.MethodOverriding.PartTimeEmployee()
        //will always call PartTimeEmployee class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee4.PrintName());

        LetsCSharp.Polymorphism.MethodOverriding.PartTimeEmployee employee5 = new LetsCSharp.Polymorphism.MethodOverriding.PartTimeEmployee()
        //will always call PartTimeEmployee class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        //typecasting
        Helper.WriteLineWithTab(((LetsCSharp.Polymorphism.MethodOverriding.Employee)employee5).PrintName());

        LetsCSharp.Polymorphism.MethodOverriding.Employee employee1 = new LetsCSharp.Polymorphism.MethodOverriding.PartTimeEmployee()
        //will call PartTime class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee1.PrintName());

        LetsCSharp.Polymorphism.MethodOverriding.Employee employee2 = new LetsCSharp.Polymorphism.MethodOverriding.FullTimeEmployee()
        //will call FullTime class method
        {
            FirstName = "FirstName",
            LastName = "LastName"
        };
        Helper.WriteLineWithTab(employee2.PrintName());
        //typecasting
        Helper.WriteLineWithTab(((LetsCSharp.Polymorphism.MethodOverriding.FullTimeEmployee)employee2).PrintName());
    }

    private static void Disposable()
    {
        using (var dispose = new DisposeExample(new IntPtr(10)))
        {
            var dispose3 = new DisposeExample(new IntPtr(10)); // this object will later get destroyed by finalizer\

        }

        var dispose1 = new DisposeExample(new IntPtr(10)); // this object will later get destroyed by finalizer\

        using (var dispose = new DisposeExample2(new IntPtr(10)))
        {

        }
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
        Abstract o = new ClassAbstract();
        o.Getname();
        o.Getname2();
        o.Getname3();


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