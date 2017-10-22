using System.Collections.Generic;

namespace BB.Core.Model.Products
{
    public class ProductType
    {
        public string Name { get; set; }

        public ProductType ParentType { get; set; }

        public List<string> AvailableCharacteristics { get; set; }
    }
}
