using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            ChildrenCategories = new List<ProductCategory>();
            Products = new List<Product>();
            Characteristics = new List<Characteristic>();
        }

        public long ProductCategoryId { get; set; }

        public string Name { get; set; }

        public long? ParentCategoryId { get; set; }

        public Guid? FacingImageId { get; set; }

        public virtual ProductPicture FacingImage { get; set; }

        public virtual ProductCategory ParentCategory { get; set; }

        public virtual ICollection<ProductCategory> ChildrenCategories { get; set; }

        public virtual ICollection<Characteristic> Characteristics { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
