using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class ShippingDataWriteDtoConvert
    {
        public static Shipping ToShipping(ShippingDataWriteDto inDto)
        {
            Shipping aShipping = null;
            if (inDto != null)
            {
                aShipping = new Shipping(inDto.Price, inDto.FirstName, inDto.LastName, inDto.Address, inDto.ZipCode, inDto.City, inDto.Phone, inDto.Email); //, inDto.Shipping
            }
            return aShipping;
        }
    }
}