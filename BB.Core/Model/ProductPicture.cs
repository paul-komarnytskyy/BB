using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class ProductPicture
    {
        public ProductPicture()
        {
            FacedProducts = new List<Product>();
        }

        public Guid ProductPictureId { get; set; }

        public string PictureUrl { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<Product> FacedProducts { get; set; }
    }
}
