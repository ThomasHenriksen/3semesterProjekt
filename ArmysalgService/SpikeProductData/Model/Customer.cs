namespace ArmysalgDataAccess.Model
{
    public class Customer : Person
    {
        public int CustomerNo { get; set; }
        public Cart Cart { get; set; }

        // Constuct a customer object.
        /// <summary>
        /// Constuct a customer object.
        /// </summary>
        public Customer()
        {
        }

        // Constuct a customer object.
        /// <summary>
        /// Constuct a customer object.
        /// </summary>
        /// <param name="firstName">First name of customer</param>
        /// <param name="lastName">Last name of customer</param>
        /// <param name="address">Address of customer</param>
        /// <param name="zipCode">Zipcode of customer</param>
        /// <param name="city">City of customer</param>
        /// <param name="phone">Phone of customer</param>
        /// <param name="email">Email of customer</param>
        /// <param name="cart">Cart of customer</param>
        public Customer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, Cart cart)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            Cart = cart;
        }

        // Constuct a customer object.
        /// <summary>
        /// Constuct a customer object.
        /// </summary>
        /// <param name="firstName">First name of customer</param>
        /// <param name="lastName">Last name of customer</param>
        /// <param name="address">Address of customer</param>
        /// <param name="zipCode">Zipcode of customer</param>
        /// <param name="city">City of customer</param>
        /// <param name="phone">Phone of customer</param>
        /// <param name="email">Email of customer</param>
        /// <param name="customerNo">Customer number of customer</param>
        public Customer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int customerNo)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            CustomerNo = customerNo;
        }
    }
}
