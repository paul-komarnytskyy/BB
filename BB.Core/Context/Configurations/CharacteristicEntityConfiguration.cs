using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class CharacteristicEntityConfiguration : EntityTypeConfiguration<Characteristic>
    {
        public CharacteristicEntityConfiguration()
        {
            HasKey(e => e.CharacteristicId);

            Property(e => e.CharacteristicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
