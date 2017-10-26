using BB.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BB.Core.Context.Configurations
{
    class CommentEntityConfiguration: EntityTypeConfiguration<Comment>
    {
        public CommentEntityConfiguration()
        {
            this.HasKey(e => e.CommentId);

            this.Property(e => e.CommentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.User)
                .WithMany(a => a.Comments)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(true);

            this.HasOptional(e => e.ParentComment)
                .WithMany(a => a.ChildComments)
                .HasForeignKey(e => e.ParentCommentId)
                .WillCascadeOnDelete(true);
        }
    }
}
