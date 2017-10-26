using System.Collections.Generic;

namespace BB.Core.Model
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public long RoleID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
