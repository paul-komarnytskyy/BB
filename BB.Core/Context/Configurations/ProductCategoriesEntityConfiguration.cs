using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class ProductCategoriesEntityConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoriesEntityConfiguration()
        {
            HasKey(e => e.ProductCategoryId);

            Property(e => e.ProductCategoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasOptional(e => e.ParentCategory)
                .WithMany(a => a.ChildrenCategories)
                .HasForeignKey(e => e.ParentCategoryId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.FacingImage)
                .WithMany(a => a.DefaultingCategory)
                .HasForeignKey(e => e.FacingImageId)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Characteristics)
                .WithMany(a => a.ProductCategories)
                .Map(cs =>
                {
                    cs.MapRightKey("CharacteristicId");
                    cs.MapLeftKey("ProductCategoryId");
                    cs.ToTable("CategoriesCaracterisitics");
                });
        }
    }
}
