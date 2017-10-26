using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class RoleEntityConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityConfiguration()
        {
            this.HasKey(e => e.RoleID);

            this.Property(e => e.RoleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(e => e.Users)
                .WithMany(a => a.Roles)
                .Map(cs =>
                {
                    cs.MapRightKey("UserID");
                    cs.MapLeftKey("RoleID");
                    cs.ToTable("UserRole");
                }); ;
        }
    }
}
