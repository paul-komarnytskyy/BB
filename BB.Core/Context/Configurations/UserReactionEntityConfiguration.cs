using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class UserReactionEntityConfiguration : EntityTypeConfiguration<UserReaction>
    {
        public UserReactionEntityConfiguration()
        {
            this.HasKey(e => e.UserReactionId);

            this.Property(e => e.UserReactionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.User)
                .WithMany(a => a.UserReactions)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            this.HasOptional(e => e.Comment)
                .WithMany(a => a.UserReactions)
                .HasForeignKey(e => e.CommentId)
                .WillCascadeOnDelete(false);

            this.HasOptional(e => e.Rating)
                .WithMany(a => a.UserReactions)
                .HasForeignKey(e => e.RatingId)
                .WillCascadeOnDelete(false);
        }
    }
}
