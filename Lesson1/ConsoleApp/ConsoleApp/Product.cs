namespace ConsoleApp
{
    class Product
    {
        public virtual string Name { get; }
        public virtual int Price { get; }
        public bool Deliverable { get; }

        public Product(string name ,int price)
        {
            Name = name;
            Price = price;
            Deliverable = true;
        }

        protected Product()
        {
            Deliverable = false;
        }
    }
}
