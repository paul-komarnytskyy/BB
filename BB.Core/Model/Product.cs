using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Product
    {
        public Product()
        {
            ProductCharacteristics = new List<ProductCharacteristic>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            ProductPictures = new List<ProductPicture>();
            OrderItems = new List<OrderItem>();
        }

        public long ProductId { get; set; }
        
        public string Name { get; set; }

        public double Price { get; set; }

        public Guid? FacingImageId { get; set; }

        public long ProductCategoryId { get; set; }


        public virtual ProductPicture FacingImage { get; set; }

        public virtual ProductDetails ProductDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<ProductPicture> ProductPictures { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
