using BB.Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class StatusUpdateEntityConfiguration : EntityTypeConfiguration<StatusUpdate>
    {
        public StatusUpdateEntityConfiguration()
        {
            this.HasKey(e => new { e.OrderId, e.Status, e.Date });

            this.HasRequired(e => e.Order)
                .WithMany(a => a.StatusUpdates)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);
        }
    }
}
