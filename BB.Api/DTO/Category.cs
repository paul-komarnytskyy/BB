using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class Category
    {
        public Category()
        {
            Children = new List<Category>();
        }

        public long ProductCategoryId { get; set; }

        public string Name { get; set; }

        public string FacingImageURL { get; set; }

        public List<Category> Children { get; set; }
    }
}