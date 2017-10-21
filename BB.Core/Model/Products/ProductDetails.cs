using System.Collections.Generic;

namespace BB.Core.Model.Products
{
    public class ProductDetails
    {
        public string Description { get; set; }

        public List<ProductCharacteristic> Characteristics { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<string> ImageURLs { get; set; }
    }
}
