using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class ProductPictureEntityConfiguration : EntityTypeConfiguration<ProductPicture>
    {
        public ProductPictureEntityConfiguration()
        {
            HasKey(e => e.ProductPictureId);

            Property(e => e.ProductPictureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.Product)
                .WithMany(a => a.ProductPictures)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
