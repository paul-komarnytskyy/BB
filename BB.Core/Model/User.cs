using System.Collections.Generic;

namespace BB.Core.Model
{
    public class User
    {
        public User()
        {
            Comments = new List<Comment>();
            Roles = new List<Role>();
            Ratings = new List<Rating>();
            UserReactions = new List<UserReaction>();
            Orders = new List<Order>();
        }

        public long UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int LoyaltyStatus { get; set; }

        public virtual UserDetails UserDetails { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<UserReaction> UserReactions { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
