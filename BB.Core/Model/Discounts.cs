using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Core.Model
{
    public class Discount
    {
        public Discount()
        {
            UserDiscounts = new List<UserDiscount>();
        }

        public int DiscountId { get; set; }
        
        public string Name { get; set; }

        public decimal DiscountValue { get; set; }

        public virtual ICollection<UserDiscount> UserDiscounts { get; set; }
    }
}
