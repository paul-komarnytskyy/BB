using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.Models.CreateModels
{
    public class ProductEditModel
    {
        public long ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Guid? ImageId { get; set; }

        public long ProductCategoryId { get; set; }

        public string Description { get; set; }
    }
}