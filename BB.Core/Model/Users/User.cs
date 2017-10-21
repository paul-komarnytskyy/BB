using System.Collections.Generic;
using BB.Core.Model.Orders;

namespace BB.Core.Model.Users
{
    public class User
    {
        public string Username { get; set; }

        public List<Role> Roles { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long UserID { get; set; }

        public UserDetails Details { get; set; }

        public UserHistory History { get; set; }

        public Order Cart { get; set; }
    }
}
