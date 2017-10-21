using System;

namespace BB.Core.Model.Users
{
    public class UserDetails
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
    }
}
