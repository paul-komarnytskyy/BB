using System;

namespace BB.Core.Model
{
    public class UserDetails
    {
        public long UserID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        public virtual User User { get; set; }
    }
}
