using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutputBased.Linq;

namespace OutputBased
{
    internal class Linq
    {

        public class Order
        {
            public int Id { get; set; }
            public List<OrderItem> Items { get; set; }
        }

        public class OrderItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }


        public static void Display()
        {
            var data = new List<string>
                {
                    "John|A|10|Pune",
                    "John1|B|20|Pune",
                    "Alice|C|5|Pune",
                    "Bob|D|15|Pune"
                };


            var res = data
                .Select(x => x.Split("|"))
                .Select(y =>
                new
                {
                    Name = y[0],
                    LName = y[1],
                    Age = Convert.ToInt16(y[2]),
                    City = y[3]
                }).OrderBy(x => x.Age).ToList();

            //    .Select(y =>
            //                new
            //                {
            //                    Name = y[0],
            //                    LName = y[1],
            //                    Age = (int)y[2],
            //                    City = y[3],
            //                }).OrderBy(x => x.Age)).ToList();

            //Console.WriteLine(res[0]);


            foreach (var item in res) { Console.WriteLine(item); }

            //Given a List<Order> where each Order has a List<OrderItem>, write a LINQ query to get the
            //total sales amount for each product across all orders.
            var orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = 101, ProductName = "Laptop", Quantity = 2, UnitPrice = 1200m },
                    new OrderItem { ProductId = 102, ProductName = "Mouse", Quantity = 5, UnitPrice = 25m }
                }
            },
            new Order
            {
                Id = 2,
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = 101, ProductName = "Laptop", Quantity = 1, UnitPrice = 1200m },
                    new OrderItem { ProductId = 103, ProductName = "Keyboard", Quantity = 3, UnitPrice = 45m }
                }
            },
            new Order
            {
                Id = 3,
                Items = new List<OrderItem>
                {
                    new OrderItem { ProductId = 102, ProductName = "Mouse", Quantity = 2, UnitPrice = 25m },
                    new OrderItem { ProductId = 103, ProductName = "Keyboard", Quantity = 1, UnitPrice = 45m }
                }
            }
        };


            var totalSalesPerProduct = orders
            .SelectMany(o => o.Items)
            .GroupBy(item => new { item.ProductId, item.ProductName })
            .Select(g => new
            {
                g.Key.ProductId,
                g.Key.ProductName,
                TotalSales = g.Sum(i => i.Quantity * i.UnitPrice)
            }).ToList();

        }

    }
}
