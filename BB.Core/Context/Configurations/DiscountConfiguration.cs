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
    public class DiscountConfiguration : EntityTypeConfiguration<Discount>
    {
        public DiscountConfiguration()
        {
            HasKey(e => e.DiscountId);

            Property(e => e.DiscountId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
                    
    }
}
