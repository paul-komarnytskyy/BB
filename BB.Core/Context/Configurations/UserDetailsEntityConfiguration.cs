using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class UserDetailsEntityConfiguration : EntityTypeConfiguration<UserDetails>
    {
        public UserDetailsEntityConfiguration()
        {
            HasKey(e => e.UserID);

            HasRequired(e => e.User)
                .WithRequiredDependent(a => a.UserDetails)
                .WillCascadeOnDelete(false);
        }
    }
}
