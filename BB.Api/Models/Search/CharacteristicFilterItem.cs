using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.Models
{
    public class CharacteristicFilterItem
    {
        public Guid CharacteristicId { get; set; }

        public string Value { get; set; }
    }
}