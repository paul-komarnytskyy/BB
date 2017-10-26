using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {
            this.HasKey(e => e.ProductId);

            this.Property(e => e.ProductId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.FacingImage)
                .WithMany(a => a.FacedProducts)
                .HasForeignKey(e => e.FacingImageId)
                .WillCascadeOnDelete(true);

            this.HasRequired(e => e.ProductCategory)
                .WithMany(a => a.Products)
                .HasForeignKey(e => e.ProductCategoryId)
                .WillCascadeOnDelete(true);
        }
    }
}
