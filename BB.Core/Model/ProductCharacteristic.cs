using System;

namespace BB.Core.Model
{
    public class ProductCharacteristic
    {
        public int ProductId { get; set; }

        public Guid CharacteristicId { get; set; }

        public string Value { get; set; }

        public virtual Product Product { get; set; }

        public virtual Characteristic Characteristic { get; set; }
    }
}
