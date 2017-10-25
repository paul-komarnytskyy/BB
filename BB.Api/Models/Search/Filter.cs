using System.Collections.Generic;
using BB.Core.Model.Products;

namespace BB.Api.Models
{
    public class SearchFilter
    {
        public ProductCategory Category { get; set; }

        public string Query { get; set; }

        public List<ProductCharacteristic> SelectedCharacteristics;

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }
    }
}