using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.DTO
{
    public class ProductCharacteristic
    {
        public long ProductId { get; set; }

        public string Value { get; set; }

        public Guid CharacteristicId { get; set; }

        public string CharacteristicName { get; set; }
    }
}