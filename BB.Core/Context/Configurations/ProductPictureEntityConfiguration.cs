using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class ProductPictureEntityConfiguration : EntityTypeConfiguration<ProductPicture>
    {
        public ProductPictureEntityConfiguration()
        {
            this.HasKey(e => e.ProductPictureId);

            this.Property(e => e.ProductPictureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.Product)
                .WithMany(a => a.ProductPictures)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(true);
        }
    }
}
