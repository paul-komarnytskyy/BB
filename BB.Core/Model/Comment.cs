using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Comment
    {
        public Comment()
        {
            UserReactions = new List<UserReaction>();
            ChildComments = new List<Comment>();
        }

        public Guid CommentId { get; set; }

        public string Text { get; set; }
        
        public DateTime DatePosted { get; set; }

        public Guid? ParentCommentId { get; set; }

        public long UserID { get; set; }


        public virtual User User { get; set; }

        public virtual Comment ParentComment { get; set; }

        public virtual ICollection<UserReaction> UserReactions { get; set; }

        public virtual ICollection<Comment> ChildComments { get; set; }
    }
}
