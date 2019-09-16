using System.Collections.Generic;

namespace Lesson3
{
    class ProductLevelComparer : IComparer<Product>
    {
        public int Compare(Product product1, Product product2)
        {
            return product1.Level - product2.Level;
        }
    }
}
