using System.Collections.Generic;
using BB.Core.Model.Products;

namespace BB.Api.Models
{
    public class SearchResults
    {
        public SearchFilter UsedFilter { get; set; }

        public List<Product> FoundProducts { get; set; }

        public List<CharacteristicsItems> CharacteristicsItems { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }
    }
}