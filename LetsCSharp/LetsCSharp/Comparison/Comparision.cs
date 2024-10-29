using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Comparison
{
    public class CustomerComparision : IComparable<CustomerComparision>
    {
        private readonly int orders;
        internal readonly string name;
        internal readonly string address;
        internal readonly int qty;

        //public CustomerComparision() { }
        public CustomerComparision(int orders, string name)
        {
            this.orders = orders;
            this.name = name;
            this.address = new Guid().ToString();
            this.qty = (new Random()).Next(1, 10);
        }

        public int CompareTo(CustomerComparision other)
        {
            if (this.orders > other.orders) return 1;
            else if (this.orders < other.orders) return -1;
            else return 0;
        }
        public override string ToString()
        {
            return $"{this.orders.ToString()} {this.name} {this.address} {this.qty}";
        }
    }

    public class SortByName : IComparer<CustomerComparision>
    {
        public int Compare(CustomerComparision x, CustomerComparision y)
        {
            return x.name.CompareTo(y.name);
        }
    }

    public class CustomerComparisionTest
    {

        public void Test()
        {
            SortByName sortByName = new();
            List<CustomerComparision> orders = new();
            orders.Add(new CustomerComparision(10, "lmno"));
            orders.Add(new CustomerComparision(1, "zebra"));
            orders.Add(new CustomerComparision(30, "abced"));
            orders.Sort();
            orders.ForEach(x => Console.WriteLine(x.ToString()));

            orders.Sort(sortByName);
            orders.ForEach(x => Console.WriteLine(x.ToString()));

            orders.Sort((x, y) => x.name.CompareTo(y.name)); // using lambda expression
            orders.ForEach(x => Console.WriteLine(x.ToString()));

            orders.Sort(
                delegate (CustomerComparision x, CustomerComparision y)
                { return x.address.CompareTo(y.address); }); // using lambda expression
            orders.ForEach(x => Console.WriteLine(x.ToString()));






        }
    }
}
