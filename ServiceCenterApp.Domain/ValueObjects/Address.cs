namespace ServiceCenterApp.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        private Address() { }

        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Address other) return false;

            return Street == other.Street &&
                   City == other.City &&
                   ZipCode == other.ZipCode;
        }

        public override int GetHashCode()
            => HashCode.Combine(Street, City, ZipCode);
    }
}