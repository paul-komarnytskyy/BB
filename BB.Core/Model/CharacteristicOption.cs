using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Core.Model
{
    public class CharacteristicOption
    {
        public Guid CharacteristicOptionId { get; set; }

        public Guid CharacteristicId { get; set; }

        public string Value { get; set; }

        public Characteristic Characteristic { get; set; }
    }
}
