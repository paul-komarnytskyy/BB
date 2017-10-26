using BB.Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class UserDetailsEntityConfiguration : EntityTypeConfiguration<UserDetails>
    {
        public UserDetailsEntityConfiguration()
        {
            this.HasKey(e => e.UserID);

            this.HasRequired(e => e.User)
                .WithRequiredDependent(a => a.UserDetails)
                .WillCascadeOnDelete(true);
        }
    }
}
