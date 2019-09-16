using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Tea", 10, 1),
                new Product("Coffee", 20, 2),
                new Product("Cola", 5, 5),
                new Product("Water", 1, 1),
                new Product("Vodocha", 100, 50)
            };

            while (true)
            {
                Console.WriteLine("1 - Sort by Name, 2 - Sort by Price, 3 - Sort by Level");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        products.Sort(new ProductNameComparer());
                        break;
                    case ConsoleKey.D2:
                        products.Sort(new ProductPriceComparer());
                        break;
                    case ConsoleKey.D3:
                        products.Sort(new ProductLevelComparer());
                        break;

                }

                Console.WriteLine("\n");
                foreach (var item in products)
                {
                    Console.WriteLine("{0, -10} {1, -6} {2, -3}", item.Name, item.Price, item.Level);
                }
                Console.WriteLine();
            }
        }
    }
    class Product
    {
        public string Name { get; }
        public int Price { get; }
        public int Level { get; }

        public Product(string name, int price, int level)
        {
            Name = name;
            Price = price;
            Level = level;
        }
    }
    class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product product1, Product product2)
        {
            return product1.Name.CompareTo(product2.Name);
        }
    }
    class ProductPriceComparer : IComparer<Product>
    {
        public int Compare(Product product1, Product product2)
        {
            return product1.Price - product2.Price;
        }
    }
    class ProductLevelComparer : IComparer<Product>
    {
        public int Compare(Product product1, Product product2)
        {
            return product1.Level - product2.Level;
        }
    }
}
