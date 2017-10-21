namespace BB.Core.Model.Products
{
    public class Product
    {
        public long ProductID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public ProductDetails Details { get; set; }

        public ProductType Type { get; set; }
    }
}
