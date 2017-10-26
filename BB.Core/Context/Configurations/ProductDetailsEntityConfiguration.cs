using BB.Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class ProductDetailsEntityConfiguration : EntityTypeConfiguration<ProductDetails>
    {
        public ProductDetailsEntityConfiguration()
        {
            this.HasKey(e => e.ProductId);

            this.HasRequired(e => e.Product)
                .WithRequiredDependent(a => a.ProductDetails)
                .WillCascadeOnDelete(false);
        }
    }
}
