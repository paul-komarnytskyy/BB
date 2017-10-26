using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class UserReactionEntityConfiguration : EntityTypeConfiguration<UserReaction>
    {
        public UserReactionEntityConfiguration()
        {
            HasKey(e => e.UserReactionId);

            Property(e => e.UserReactionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.User)
                .WithMany(a => a.UserReactions)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.Comment)
                .WithMany(a => a.UserReactions)
                .HasForeignKey(e => e.CommentId)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.Rating)
                .WithMany(a => a.UserReactions)
                .HasForeignKey(e => e.RatingId)
                .WillCascadeOnDelete(false);
        }
    }
}
