using System;

namespace BB.Core.Model
{
    public class UserReaction
    {
        public Guid UserReactionId { get; set; }

        public long UserID { get; set; }

        public Guid? CommentId { get; set; }

        public Guid? RatingId { get; set; }

        public Reaction Reaction { get; set; }

        public virtual User User { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
