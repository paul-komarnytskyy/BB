using System;

namespace BB.Core.Model
{
    public class CharacteristicOption
    {
        public Guid CharacteristicOptionId { get; set; }

        public Guid CharacteristicId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public Characteristic Characteristic { get; set; }
    }
}
