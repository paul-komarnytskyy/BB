using System;
using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Characteristic
    {
        public Characteristic()
        {
            ProductCharacteristics = new List<ProductCharacteristic>();
            ProductCategories = new List<ProductCategory>();
            CharacteristicOptions = new List<CharacteristicOption>();
        }

        public Guid CharacteristicId { get; set; }

        public string Name { get; set; }

        public int Type => 1;

        public virtual ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public virtual ICollection<CharacteristicOption> CharacteristicOptions { get; set; }
    }
}
