using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class ProductCategoriesEntityConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoriesEntityConfiguration()
        {
            this.HasKey(e => e.ProductCategoryId);

            this.Property(e => e.ProductCategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasOptional(e => e.ParentCategory)
                .WithMany(a => a.ChildrenCategories)
                .HasForeignKey(e => e.ParentCategoryId)
                .WillCascadeOnDelete(false);

            this.HasRequired(e => e.FacingImage)
                .WithMany(a => a.DefaultingCategory)
                .HasForeignKey(e => e.FacingImageId)
                .WillCascadeOnDelete(false);
        }
    }
}
