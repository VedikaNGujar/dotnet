using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputBased.GitHubOutputBased
{
    public class Product
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }


    internal class _7File
    {
        public static void Main()
        {
            Product product = new Product { Name = "Bowl", Price = 1.99m };
            //product.Name = "New Bowl"; // This line is commented
            Console.WriteLine(product.Name);
        }
    }
}
