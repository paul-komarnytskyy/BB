using System.Collections.Generic;

namespace BB.Core.Model.Orders
{
    public class Order
    {
        public long OrderID { get; set; }

        public User User { get; set; }

        public List<OrderItem> Items { get; set; }

        public List<StatusUpdate> StatusUpdates { get; set; }
    }
}
