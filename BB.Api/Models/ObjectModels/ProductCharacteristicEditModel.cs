using BB.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.Models.ObjectModels
{
    public struct ProductCharacteristicEditModel
    {
        public long ProductId { get; set; }
        public Guid CharacteristicId { get; set; }
        public string Value { get; set; }
    }
}