using System.Collections.Generic;

namespace BB.Core.Model
{
    public class ProductDetails
    {
        public int ProductId { get; set; }

        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
