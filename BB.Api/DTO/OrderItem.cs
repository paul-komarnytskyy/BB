using System;

namespace BB.Api.DTO
{
    public class OrderItem
    {
        public Guid OrderId { get; set; }

        public long ProductId { get; set; }

        public int Count { get; set; }

        public double PricePerItem { get; set; }

        public ProductShort Product { get; set; }
    }
}