using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArmysalgService.DTOs;
using ArmysalgDataAccess.ModelLayer;

namespace ArmysalgService.ModelConversion
{
    public class CustomerdataWriteDtoConvert
    {
        public static Customer ToCustomer(CustomerdataWriteDto inDto)
        {
            Customer aCustomer = null;
            if (inDto != null)
            {
                aCustomer = new Customer(inDto.FirstName, inDto.LastName, inDto.Address, inDto.ZipCode, inDto.City, inDto.Phone, inDto.Email);
            }
            return aCustomer;
        }
    }
}
