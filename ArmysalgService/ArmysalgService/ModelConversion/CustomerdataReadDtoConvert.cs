using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class CustomerDataReadDtoConvert
    {
        public static CustomerDataReadDto FromCustomer(Customer inCustomer)
        {
            CustomerDataReadDto aCustomerReadDto = null;
            if (inCustomer != null)
            {
                aCustomerReadDto = new CustomerDataReadDto(inCustomer.FirstName, inCustomer.LastName, inCustomer.Address, inCustomer.ZipCode, inCustomer.City, inCustomer.Phone, inCustomer.Email, inCustomer.CustomerNo);
            }
            return aCustomerReadDto;
        }
    }
}
