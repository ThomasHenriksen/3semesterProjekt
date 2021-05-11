namespace ArmysalgDataAccess.Model
{
    public class Shipping
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Shipping()
        {
        }

        // Consturt a shipping object.
        /// <summary>
        /// Consturt a shipping object.
        /// </summary>
        /// <param name="price">Price of shipping</param>
        /// <param name="firstName">First name of shipping</param>
        /// <param name="lastName">Last name of shipping</param>
        /// <param name="address">Address of shipping</param>
        /// <param name="zipCode">Zipcode of shipping</param>
        /// <param name="city">City of shipping</param>
        /// <param name="phone">Phone of shipping</param>
        /// <param name="email">Email of shipping</param>
        public Shipping(double price, string firstName, string lastName, string address, string zipCode,
            string city, string phone, string email)
        {
            Price = price;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
        }

        // Consturt a shipping object.
        /// <summary>
        /// Consturt a shipping object.
        /// </summary>
        /// <param name="id">Id of shipping</param>
        /// <param name="price">Price of shipping</param>
        /// <param name="firstName">First name of shipping</param>
        /// <param name="lastName">Last name of shipping</param>
        /// <param name="address">Address of shipping</param>
        /// <param name="zipCode">Zipcode of shipping</param>
        /// <param name="city">City of shipping</param>
        /// <param name="phone">Phone of shipping</param>
        /// <param name="email">Email of shipping</param>
        public Shipping(int id, double price, string firstName, string lastName, string address, string zipCode,
            string city, string phone, string email)
        {
            Id = id;
            Price = price;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
        }
    }
}