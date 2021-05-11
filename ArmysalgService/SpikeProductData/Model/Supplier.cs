namespace ArmysalgDataAccess.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Supplier()
        {

        }

        public Supplier(int id, string name, string address, string zipCode, string city, string country, string phone, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Country = country;
            Phone = phone;
            Email = email;
        }

        public Supplier(string name, string address, string zipCode, string city, string country, string phone, string email)
        {
            Name = name;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Country = country;
            Phone = phone;
            Email = email;
        }
    }
}
