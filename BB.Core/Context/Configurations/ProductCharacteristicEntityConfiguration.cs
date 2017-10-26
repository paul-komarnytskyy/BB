using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class ProductCharacteristicEntityConfiguration : EntityTypeConfiguration<ProductCharacteristic>
    {
        public ProductCharacteristicEntityConfiguration()
        {
            HasKey(e => new { e.ProductId, e.CharacteristicId });

            HasRequired(e => e.Product)
                .WithMany(a => a.ProductCharacteristics)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Characteristic)
                .WithMany(a => a.ProductCharacteristics)
                .HasForeignKey(e => e.CharacteristicId)
                .WillCascadeOnDelete(false);

        }
    }
}
