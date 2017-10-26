using System.Collections.Generic;
using BB.Api.DTO;

namespace BB.Api.Models
{
    public class SearchResults
    {
        public SearchFilter UsedFilter { get; set; }

        public List<ProductShort> FoundProducts { get; set; }

        //#TODO later
        //public List<CharacteristicsItems> CharacteristicsItems { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }

        public int TotalProductCount { get; set; }
    }
}