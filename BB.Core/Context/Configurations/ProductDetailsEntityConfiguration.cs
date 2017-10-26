using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class ProductDetailsEntityConfiguration : EntityTypeConfiguration<ProductDetails>
    {
        public ProductDetailsEntityConfiguration()
        {
            HasKey(e => e.ProductId);

            HasRequired(e => e.Product)
                .WithRequiredDependent(a => a.ProductDetails)
                .WillCascadeOnDelete(false);
        }
    }
}
