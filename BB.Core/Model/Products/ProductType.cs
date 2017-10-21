namespace BB.Core.Model.Products
{
    public class ProductType
    {
        public string Name { get; set; }

        public ProductType ParentType { get; set; }
    }
}
