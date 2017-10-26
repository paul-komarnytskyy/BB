using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class OrderEntityConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderEntityConfiguration()
        {
            this.HasKey(e => e.OrderId);

            this.Property(e => e.OrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.User)
                .WithMany(a => a.Orders)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
