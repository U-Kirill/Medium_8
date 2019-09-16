using System.Collections.Generic;

namespace Lesson3
{
    class ProductNameComparer : IComparer<Product>
    {
        public int Compare(Product product1, Product product2)
        {
            return product1.Name.CompareTo(product2.Name);
        }
    }
}
