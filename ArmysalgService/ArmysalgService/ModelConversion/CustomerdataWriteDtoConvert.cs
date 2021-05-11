using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class CustomerdataWriteDtoConvert
    {
        public static Customer ToCustomer(CustomerdataWriteDto inDto)
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
