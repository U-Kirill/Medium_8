namespace Lesson3
{
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
}
