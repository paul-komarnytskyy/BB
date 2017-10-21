using System;
using BB.Core.Model.Users;

namespace BB.Core.Model.Products
{
    public class Comment
    {
        public long CommentID { get; set; }

        public Comment ParentComment { get; set; }

        public string Text { get; set; }

        public DateTime DatePosted { get; set; }

        public User Author { get; set; }
    }
}
