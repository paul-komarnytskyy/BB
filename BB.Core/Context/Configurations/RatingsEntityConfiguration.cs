using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class RatingsEntityConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingsEntityConfiguration()
        {
            this.HasKey(e => e.RatingId);

            this.Property(e => e.RatingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.User)
                .WithMany(a => a.Ratings)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(true);

            this.HasRequired(e => e.Product)
                .WithMany(a => a.Ratings)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(true);
        }
    }
}
