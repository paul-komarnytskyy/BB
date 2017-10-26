using BB.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class UserReaction
    {
        public Guid UserReactionId { get; set; }

        public long UserID { get; set; }

        public Reaction Reaction { get; set; }
    }


}