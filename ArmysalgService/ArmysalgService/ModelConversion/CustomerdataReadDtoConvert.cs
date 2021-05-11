using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class CustomerdataReadDtoConvert
    {
        public static CustomerdataReadDto FromCustomer(Customer inCustomer)
        {
            CustomerdataReadDto aCustomerReadDto = null;
            if (inCustomer != null)
            {
                aCustomerReadDto = new CustomerdataReadDto(inCustomer.FirstName, inCustomer.LastName, inCustomer.Address, inCustomer.ZipCode, inCustomer.City, inCustomer.Phone, inCustomer.Email, inCustomer.CustomerNo);
            }
            return aCustomerReadDto;
        }
    }
}
