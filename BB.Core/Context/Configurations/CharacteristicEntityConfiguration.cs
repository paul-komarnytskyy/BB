using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class CharacteristicEntityConfiguration : EntityTypeConfiguration<Characteristic>
    {
        public CharacteristicEntityConfiguration()
        {
            this.HasKey(e => e.CharacteristicId);

            this.Property(e => e.CharacteristicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
