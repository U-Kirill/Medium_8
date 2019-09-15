using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Product prod = new Product("name", 100);
            Product discountedProduct = new DiscountedProduct(prod, 50);

            Console.WriteLine(prod.Name + " - " + prod.Price+ " Deliverable: "+prod.Deliverable);
            Console.WriteLine(discountedProduct.Name + " - " + discountedProduct.Price + " Deliverable: " + discountedProduct.Deliverable);
            Console.ReadLine();
        }
    }
}
