using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class CustomerDataWriteDtoConvert
    {
        public static Customer ToCustomer(CustomerDataWriteDto inDto)
        {
            Customer aCustomer = null;
            if (inDto != null)
            {
                aCustomer = new Customer(inDto.FirstName, inDto.LastName, inDto.Address, inDto.ZipCode, inDto.City, inDto.Phone, inDto.Email, inDto.Cart);
            }
            return aCustomer;
        }
    }
}
