using System.Collections.Generic;
using BB.Api.DTO;

namespace BB.Api.Models
{
    public class SearchFilter
    {
        public long CategoryId { get; set; }

        public string Query { get; set; }

        public List<ProductCharacteristic> SelectedCharacteristics;

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}