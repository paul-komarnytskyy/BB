using System.Collections.Generic;

namespace BB.Core.Model
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            ChildrenCategories = new List<ProductCategory>();
            Products = new List<Product>();
        }

        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }


        public virtual ProductCategory ParentCategory { get; set; }

        public virtual ICollection<ProductCategory> ChildrenCategories { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
