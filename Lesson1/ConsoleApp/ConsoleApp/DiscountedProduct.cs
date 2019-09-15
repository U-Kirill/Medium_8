namespace ConsoleApp
{
    class DiscountedProduct : Product
    {
        private Product _product;

        public override string Name => _product.Name;
        public override int Price => (int)(_product.Price - _product.Price * (Percent/100));
        public float Percent { get; }

        public DiscountedProduct(Product product, int percent)
        {
            _product = product;
            Percent = percent;
        }
    }
}
