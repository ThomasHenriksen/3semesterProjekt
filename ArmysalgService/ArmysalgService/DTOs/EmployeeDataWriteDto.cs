namespace ArmysalgService.DTOs
{
    public class EmployeeDataWriteDto : PersonDataWriteDto
    {
        public int EmployeeNo { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }

        public EmployeeDataWriteDto()
        {
        }

        public EmployeeDataWriteDto(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, double salary, string position)
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

        public EmployeeDataWriteDto(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int employeeNo, double salary, string position)
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