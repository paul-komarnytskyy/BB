using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            HasKey(e => e.UserID);

            Property(e => e.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
