using System.Collections.Generic;
using BB.Core.Model.Orders;
using BB.Core.Model.Products;

namespace BB.Core.Model.Users
{
    public class UserHistory
    {
        public List<Product> LastViewed { get; set; }

        public List<Order> Orders { get; set; }
    }
}
