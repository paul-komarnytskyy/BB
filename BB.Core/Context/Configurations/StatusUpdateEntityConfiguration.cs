using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class StatusUpdateEntityConfiguration : EntityTypeConfiguration<StatusUpdate>
    {
        public StatusUpdateEntityConfiguration()
        {
            HasKey(e => new { e.OrderId, e.Status, e.Date });

            HasRequired(e => e.Order)
                .WithMany(a => a.StatusUpdates)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);
        }
    }
}
