using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class RatingsEntityConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingsEntityConfiguration()
        {
            HasKey(e => e.RatingId);

            Property(e => e.RatingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.User)
                .WithMany(a => a.Ratings)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Product)
                .WithMany(a => a.Ratings)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
