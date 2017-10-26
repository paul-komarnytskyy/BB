using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
            StatusUpdates = new List<StatusUpdate>();
        }

        public Guid OrderId { get; set; }

        public long UserID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<StatusUpdate> StatusUpdates { get; set; }
    }
}
