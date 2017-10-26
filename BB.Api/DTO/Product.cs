using System.Collections.Generic;

namespace BB.Api.DTO
{
    public class Product
    {
        public Product()
        {
            ProductCharacteristics = new List<ProductCharacteristic>();
            Images = new List<string>();
        }

        public long ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public CategoryShort ProductCategory { get; set; }

        public ProductDetails ProductDetails { get; set; }

        public List<ProductCharacteristic> ProductCharacteristics { get; set; }

        public List<string> Images { get; set; }
    }
}