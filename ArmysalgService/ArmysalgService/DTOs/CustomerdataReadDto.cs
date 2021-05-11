namespace ArmysalgService.DTOs
{
    public class CustomerDataReadDto : PersonDataReadDto
    {
        public int CustomerNo { get; set; }

        public CustomerDataReadDto()
        {
        }

        public CustomerDataReadDto(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int customerNo)
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
