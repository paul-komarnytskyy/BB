using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class RoleEntityConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityConfiguration()
        {
            HasKey(e => e.RoleID);

            Property(e => e.RoleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(e => e.Users)
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
