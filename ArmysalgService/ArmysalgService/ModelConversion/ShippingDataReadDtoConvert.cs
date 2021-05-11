using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System.Collections.Generic;

namespace ArmysalgService.ModelConversion
{
    public class ShippingDataReadDtoConvert
    {
        public static ShippingDataReadDto FromShipping(Shipping inShipping)
        {
            ShippingDataReadDto aShippingReadDto = null;
            if (inShipping != null)
            {
                aShippingReadDto = new ShippingDataReadDto(inShipping.Price, inShipping.FirstName, inShipping.LastName, inShipping.Address, inShipping.ZipCode, inShipping.City, inShipping.Phone, inShipping.Email);
            }
            return aShippingReadDto;
        }
    }
}