namespace ArmysalgService.DTOs
{
    public class CustomerdataReadDto : PersondataReadDto
    {
        public int CustomerNo { get; set; }

        public CustomerdataReadDto()
        {
        }

        public CustomerdataReadDto(string firstName, string lastName, string address, string zipCode, string city, string phone, string email, int customerNo)
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
