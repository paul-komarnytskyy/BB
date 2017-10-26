using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Characteristic
    {
        public Characteristic()
        {
            ProductCharacteristics = new List<ProductCharacteristic>();
        }

        public Guid CharacteristicId { get; set; }

        public string Name { get; set; }

        public int Type => 1;

        public virtual ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }
    }
}
