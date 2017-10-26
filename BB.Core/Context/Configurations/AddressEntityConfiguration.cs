using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class AddressEntityConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            HasKey(e => e.UserID);

            HasRequired(e => e.UserDetails)
                .WithRequiredDependent(a => a.Address)
                .WillCascadeOnDelete(false);

        }
    }
}
