using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class ShippingDataReadDtoConvert
    {
        public static ShippingDataReadDto FromShipping(Shipping inShipping)
        {
            ShippingDataReadDto aShippingReadDto = null;
            if (inShipping != null)
            {
                aShippingReadDto = new ShippingDataReadDto(inShipping.Price, inShipping.FreeShipping, inShipping.FirstName, inShipping.LastName, inShipping.Address, inShipping.ZipCode, inShipping.City, inShipping.Phone, inShipping.Email);
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