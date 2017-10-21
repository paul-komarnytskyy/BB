using BB.Core.Model.Users;

namespace BB.Core.Model.Products
{
    public class Rating
    {
        public User User { get; set; }

        public int Value { get; set; }
        
        public string Comment { get; set; }
    }
}
