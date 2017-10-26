namespace BB.Core.Model
{
    public class ProductDetails
    {
        public long ProductId { get; set; }

        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
