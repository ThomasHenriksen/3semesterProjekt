using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class SupplierDataReadDtoConvert
    {
        public static SupplierDataReadDto FromSupplier(Supplier inSupplier)
        {
            SupplierDataReadDto aSupplierReadDto = null;
            if (inSupplier != null)
            {
                aSupplierReadDto = new SupplierDataReadDto(inSupplier.Id, inSupplier.Name, inSupplier.Address, inSupplier.ZipCode, inSupplier.City, inSupplier.Country, inSupplier.Phone, inSupplier.Email);
            }
            return aSupplierReadDto;
        }
        
        public static List<SupplierDataReadDto> FromSupplierCollection(List<Supplier> suppliers)
        {
            List<SupplierDataReadDto> anSupplierCollection = null;
            if (suppliers != null)
            {
                anSupplierCollection = new List<SupplierDataReadDto>();
                SupplierDataReadDto tempDto;
                foreach (Supplier anSupplier in suppliers)
                {
                    tempDto = FromSupplier(anSupplier);
                    anSupplierCollection.Add(tempDto);
                }
            }
            return anSupplierCollection;
        }

    }
}
