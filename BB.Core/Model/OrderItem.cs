using System;

namespace BB.Core.Model
{
    public class OrderItem
    {
        public Guid OrderId { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public double PricePerItem { get; set; }

        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }
    }
}
