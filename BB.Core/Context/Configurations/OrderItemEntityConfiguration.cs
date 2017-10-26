using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class OrderItemEntityConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemEntityConfiguration()
        {
            this.HasKey(e => new { e.OrderId, e.ProductId });

            this.HasRequired(e => e.Product)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(true);

            this.HasRequired(e => e.Order)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(true);
        }
    }
}
