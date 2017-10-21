using System.Collections.Generic;
using BB.Core.Model.Users;

namespace BB.Core.Model.Orders
{
    public class Order
    {
        public User User { get; set; }

        public List<OrderItem> Items { get; set; }

        public List<StatusUpdate> StatusUpdates { get; set; }
    }
}
