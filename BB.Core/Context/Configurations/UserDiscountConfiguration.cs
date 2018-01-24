using BB.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Core.Context.Configurations
{
    public class UserDiscountConfiguration : EntityTypeConfiguration<UserDiscount>
    {
        public UserDiscountConfiguration()
        {
            HasKey(e => new { e.UserID, e.DiscountId });

            HasRequired(e => e.User)
                .WithMany(a => a.UserDiscounts)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Discount)
                .WithMany(a => a.UserDiscounts)
                .HasForeignKey(e => e.DiscountId)
                .WillCascadeOnDelete(false);
        }
    }
}
