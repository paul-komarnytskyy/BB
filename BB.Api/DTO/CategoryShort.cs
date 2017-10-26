using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class CategoryShort
    {
        public long ProductCategoryId { get; set; }

        public string Name { get; set; }

        public string FacingImageURL { get; set; }

        public CategoryShort Parent { get; set; }
    }
}