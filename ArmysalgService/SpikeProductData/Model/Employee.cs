namespace ArmysalgDataAccess.Model
{
    public class Employee : Person
    {
        public int EmployeeNo { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public Employee()
        {

        }

        // Constuct a employee object.
        /// <summary>
        /// Constuct a employee object.
        /// </summary>
        /// <param name="firstName">First name of employee</param>
        /// <param name="lastName">Last name of employee</param>
        /// <param name="address">Address of employee</param>
        /// <param name="zipCode">Zipcode of employee</param>
        /// <param name="city">City of employee</param>
        /// <param name="phone">Phone of employee</param>
        /// <param name="email">Email of employee</param>
        /// <param name="salary">Cart of employee</param>
        /// <param name="position">Cart of employee</param>
        public Employee(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, double salary, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            Salary = salary;
            Position = position;
        }

        // Constuct a employee object.
        /// <summary>
        /// Constuct a employee object.
        /// </summary>
        /// <param name="firstName">First name of employee</param>
        /// <param name="lastName">Last name of employee</param>
        /// <param name="address">Address of employee</param>
        /// <param name="zipCode">Zipcode of employee</param>
        /// <param name="city">City of employee</param>
        /// <param name="phone">Phone of employee</param>
        /// <param name="email">Email of employee</param>
        /// <param name="employeeNo">Email of employee</param>
        /// <param name="salary">Cart of employee</param>
        /// <param name="position">Cart of employee</param>
        public Employee(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int employeeNo, double salary, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            ZipCode = zipCode;
            City = city;
            Phone = phone;
            Email = email;
            EmployeeNo = employeeNo;
            Salary = salary;
            Position = position;
        }
    }
}