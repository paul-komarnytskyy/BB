using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class OrderItemEntityConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemEntityConfiguration()
        {
            HasKey(e => new { e.OrderId, e.ProductId });

            HasRequired(e => e.Product)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Order)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);
        }
    }
}
