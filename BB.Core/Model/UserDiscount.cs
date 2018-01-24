using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Core.Model
{
    public class UserDiscount
    {
        public long UserID { get; set; }

        public int DiscountId { get; set; }

        public virtual User User { get; set; }

        public virtual Discount Discount { get; set; }
    }
}
