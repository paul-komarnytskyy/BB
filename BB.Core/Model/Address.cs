namespace BB.Core.Model
{
    public class Address
    {
        public long UserID { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public int PostalCode { get; set; }

        public virtual UserDetails UserDetails { get; set; }
    }
}
