using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class ShippingDataWriteDtoConvert
    {
        public Shipping ShippingToConvert(ShippingDataWriteDto inDto)
        {
            Shipping aShipping= null;
            if (inDto != null)
            {
                aShipping = new Shipping(inDto.Price, inDto.FreeShipping, inDto.FirstName, inDto.LastName, inDto.Address, inDto.ZipCode, inDto.City, inDto.Phone, inDto.Email);
            }
            return aShipping;
        }
    }
}