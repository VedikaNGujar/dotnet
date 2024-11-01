using LetsCSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.LinQ
{
    internal static class Partitioning
    {
        public static void Test()
        {
            Console.WriteLine("---Partitioning---");
            CommonHelper.InitializeData();


            string[] countries = { "India", "USA", "UK", "Australia", "South Africa" };
            var country = (from countrie in countries
                           select countrie).Take(3);

            Console.WriteLine("------");
            Console.WriteLine("Take Country Name : ");
            Console.WriteLine("------");
            country.ToList().ForEach(x => Console.WriteLine(x));

            country = (from countrie in countries
                       select countrie).Skip(2);

            Console.WriteLine("------");
            Console.WriteLine("Skip Country Name : ");
            Console.WriteLine("------");
            country.ToList().ForEach(x => Console.WriteLine(x));

            country = (from countrie in countries
                       select countrie).TakeWhile(x => x.Length > 2);

            Console.WriteLine("------");
            Console.WriteLine("Take While Country Name : ");
            Console.WriteLine("------");
            country.ToList().ForEach(x => Console.WriteLine(x));

            country = (from countrie in countries
                       select countrie).TakeWhile((x, y) => x.Length > 2 && y < 1);

            Console.WriteLine("------");
            Console.WriteLine("Take While with index Country Name : ");
            Console.WriteLine("------");
            country.ToList().ForEach(x => Console.WriteLine(x));

            country = (from countrie in countries
                       select countrie).SkipWhile(x => x.Length > 2);

            Console.WriteLine("------");
            Console.WriteLine("Skip While Country Name : ");
            Console.WriteLine("------");
            country.ToList().ForEach(x => Console.WriteLine(x));

            country = (from countrie in countries
                       select countrie).SkipWhile((x, y) => x.Length > 2 && y < 1);

            Console.WriteLine("------");
            Console.WriteLine("Skip While with index Country Name : ");
            Console.WriteLine("------");
            country.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
