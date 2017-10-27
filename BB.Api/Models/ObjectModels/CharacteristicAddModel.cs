using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB.Api.Models.ObjectModels
{
    public class CharacteristicAddModel
    {
        public long CategoryId { get; set; }

        public string Name { get; set; }

        public List<string> Options { get; set; }
    }
}