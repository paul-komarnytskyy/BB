using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class CharacteristicOptionEntityConfiguration : EntityTypeConfiguration<CharacteristicOption>
    {
        public CharacteristicOptionEntityConfiguration()
        {
            this.HasKey(e => e.CharacteristicOptionId);

            this.Property(e => e.CharacteristicOptionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.Characteristic)
                .WithMany(a => a.CharacteristicOptions)
                .HasForeignKey(e => e.CharacteristicId)
                .WillCascadeOnDelete(false);
        }
    }
}