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
        public static List<ShippingDataReadDto> FromShippingCollection(List<Shipping> shippings)
        {
            List<ShippingDataReadDto> aShippingCollection = null;
            if (shippings != null)
            {
                aShippingCollection = new List<ShippingDataReadDto>();
                ShippingDataReadDto tempDto;
                foreach (Shipping aShipping in shippings)
                {
                    tempDto = FromShipping(aShipping);
                    aShippingCollection.Add(tempDto);
                }
            }
            return aShippingCollection;
        }
    }
}