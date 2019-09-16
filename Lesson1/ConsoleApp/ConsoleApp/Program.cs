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
            List<Product> products = new List<Product>
            {
                new Product(0,"first",80, 2),
                new Product(1,"second",120, 50),
                new Product(2,"third",20, 1000),
                new Product(3,"fourth",300, 0),
                new Product(3,"fifth",95, 6)
            };

            foreach (var item in products.Where(product => product.Price < 100 && product.Count > 5))
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }

}
