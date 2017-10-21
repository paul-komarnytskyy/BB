using BB.Core.Model.Products;

namespace BB.Core.Model.Orders
{
    public class OrderItem
    {
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
