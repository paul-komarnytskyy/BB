using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {
            HasKey(e => e.ProductId);

            Property(e => e.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.FacingImage)
                .WithMany(a => a.FacedProducts)
                .HasForeignKey(e => e.FacingImageId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.ProductCategory)
                .WithMany(a => a.Products)
                .HasForeignKey(e => e.ProductCategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
