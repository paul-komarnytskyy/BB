using System;
using System.Collections.Generic;

namespace BB.Api.DTO
{
    public class Comment
    {
        public Comment()
        {
            Children = new List<Comment>();
            Reactions = new List<UserReaction>();
        }

        public Guid CommentId { get; set; }

        public string Text { get; set; }

        public DateTime DatePosted { get; set; }

        public long UserID { get; set; }

        public string UserName { get; set; }

        public long? ProductId { get; set; }

        public List<Comment> Children { get; set; }

        public List<UserReaction> Reactions { get; set; }
    }
}