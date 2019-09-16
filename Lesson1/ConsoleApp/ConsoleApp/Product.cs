namespace ConsoleApp
{
    class Product
    {
        public int Id { get; }
        public string Name { get; }
        public int Price { get; }
        public int Count { get; private set; }

        public Product(int id, string name, int price, int count)
        {
            Id = id;
            Name = name;
            Price = price;
            Count = count;
        }
    }

}
