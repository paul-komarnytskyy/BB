using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Rating
    {
        public Rating()
        {
            UserReactions = new List<UserReaction>();
        }

        public Guid RatingId { get; set; }

        public long UserID { get; set; }

        public long ProductId { get; set; }

        public int Value { get; set; }
        
        public string Comment { get; set; }


        public virtual User User { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<UserReaction> UserReactions { get; set; }
    }
}
