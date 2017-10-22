using System.Collections.Generic;

namespace BB.Core.Model.Products
{
    public class ProductCategory
    {
        public string Name { get; set; }

        public ProductCategory ParentCategory { get; set; }

        public List<string> AvailableCharacteristics { get; set; }
    }
}
