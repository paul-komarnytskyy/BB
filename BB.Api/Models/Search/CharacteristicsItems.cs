using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BB.Core.Model.Products;

namespace BB.Api.Models
{
    public class CharacteristicsItems
    {
        public ProductCharacteristic Characteristic { get; set; }

        public int ItemsCount { get; set; }
    }
}