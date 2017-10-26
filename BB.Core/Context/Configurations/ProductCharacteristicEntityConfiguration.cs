using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class ProductCharacteristicEntityConfiguration : EntityTypeConfiguration<ProductCharacteristic>
    {
        public ProductCharacteristicEntityConfiguration()
        {
            this.HasKey(e => new { e.ProductId, e.CharacteristicId });

            this.HasRequired(e => e.Product)
                .WithMany(a => a.ProductCharacteristics)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(true);

            this.HasRequired(e => e.Characteristic)
                .WithMany(a => a.ProductCharacteristics)
                .HasForeignKey(e => e.CharacteristicId)
                .WillCascadeOnDelete(true);

        }
    }
}
