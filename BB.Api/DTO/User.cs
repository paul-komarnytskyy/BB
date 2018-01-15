using System.Collections.Generic;

namespace BB.Api.DTO
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public long UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int LoyaltyStatus { get; set; }

        public List<Role> Roles { get; set; }
    }
}