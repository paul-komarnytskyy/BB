namespace BB.Core.Model.Products
{
    public class ProductType
    {
        public long TypeID { get; set; }
        
        public string Name { get; set; }

        public ProductType ParentType { get; set; }
    }
}
