using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;

namespace ArmysalgService.ModelConversion
{
    public class CartdataReadDtoConvert
    {
        public static CartdataReadDto FromCart(Cart inCart)
        {
            CartdataReadDto aCartReadDto = null;
            if (inCart != null)
            {
                aCartReadDto = new CartdataReadDto(inCart.Id, inCart.LastUpdated, inCart.SalesLineItems);
            }
            return aCartReadDto;
        }
    }
}
