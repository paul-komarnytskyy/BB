using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class OrderEntityConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderEntityConfiguration()
        {
            HasKey(e => e.OrderId);

            Property(e => e.OrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.User)
                .WithMany(a => a.Orders)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
