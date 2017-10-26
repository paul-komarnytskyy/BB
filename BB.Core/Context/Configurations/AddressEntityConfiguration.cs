using BB.Core.Model;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class AddressEntityConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            this.HasKey(e => e.UserID);

            this.HasRequired(e => e.UserDetails)
                .WithRequiredDependent(a => a.Address)
                .WillCascadeOnDelete(true);

        }
    }
}
