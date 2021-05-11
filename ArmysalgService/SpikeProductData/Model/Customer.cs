namespace ArmysalgDataAccess.Model
{
    public class Customer : Person
    {
        public int CustomerNo { get; set; }
        public Cart Cart { get; set; }

        public Customer()
        {
        }

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
        public Customer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, Cart cart, int customerNo)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            Cart = cart;
            CustomerNo = customerNo;
        }
    }
}
