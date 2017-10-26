using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BB.Core.Model;

namespace BB.Core.Context.Configurations
{
    class CommentEntityConfiguration: EntityTypeConfiguration<Comment>
    {
        public CommentEntityConfiguration()
        {
            HasKey(e => e.CommentId);

            Property(e => e.CommentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.User)
                .WithMany(a => a.Comments)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            HasOptional(e => e.ParentComment)
                .WithMany(a => a.ChildComments)
                .HasForeignKey(e => e.ParentCommentId)
                .WillCascadeOnDelete(false);

            this.HasOptional(e => e.Product)
                .WithMany(a => a.Comments)
                .HasForeignKey(e => e.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
