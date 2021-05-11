using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

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
