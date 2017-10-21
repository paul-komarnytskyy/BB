using BB.Core.Model.Users;

namespace BB.Core.Model.Products
{
    public class UserReaction
    {
        public Reaction Reaction { get; set; }

        public User User { get; set; }
    }
}
