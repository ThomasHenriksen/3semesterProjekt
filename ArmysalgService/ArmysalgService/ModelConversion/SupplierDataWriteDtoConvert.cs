using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class SupplierDataWriteDtoConvert
    {
        public static Supplier ToSupplier(SupplierDataWriteDto inDto)
        {
            Supplier aSupplier = null;
            if (inDto != null)
            {
                aSupplier = new Supplier(inDto.Name, inDto.Address, inDto.ZipCode, inDto.City, inDto.Country, inDto.Phone, inDto.Email);
            }
            return aSupplier;
        }
    }
}
