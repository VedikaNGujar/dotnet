using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased
{
    internal class LinqOperations
    {
        public static void Approach1()
        {
            List<Person> people = new List<Person>
            {
               new Person { Id = 1, Name = "Alice", Age = 28, City = "New York" },
               new Person { Id = 2, Name = "Bob", Age = 35, City = "New York" },
               new Person { Id = 3, Name = "Charlie", Age = 22, City = "Los Angeles" },
               new Person { Id = 4, Name = "David", Age = 30, City = "Chicago" },
               new Person { Id = 5, Name = "Eva", Age = 25, City = "Los Angeles" }
            };


            var result = people
                .GroupBy(x => x.City)
                .Select(x => new
                {
                    City = x.Key,
                    AvgAge = x.Select(y => y.Age).Average()
                }).Where(x => x.AvgAge >= 30).ToList();

            foreach (var r in result)
            {
                Console.WriteLine($"City : {r.City} AvgAge : {r.AvgAge}");
            }
        }
    }

    internal class Person
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public int Age { get; internal set; }
        public string City { get; internal set; }
    }
}
