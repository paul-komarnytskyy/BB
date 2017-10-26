using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class Rating
    {
        public Guid RatingId { get; set; }

        public long UserID { get; set; }

        public string UserName { get; set; }

        public long ProductId { get; set; }

        public int Value { get; set; }

        public string Comment { get; set; }

        public List<UserReaction> Reactions { get; set; }
    }
}