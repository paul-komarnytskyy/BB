using BB.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public Guid OrderId { get; set; }

        public long UserID { get; set; }

        public Status Status { get; set; }

        public DateTime Date { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}