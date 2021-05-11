using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class CartdataWriteDtoConvert
    {
        public static Cart ToCart(CartdataWriteDto inDto)
        {
            Cart aCart = null;
            if (inDto != null)
            {
                aCart = new Cart(inDto.LastUpdated, inDto.SalesLineItems);
            }
            return aCart;
        }
    }
}