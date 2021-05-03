using ArmysalgDataAccess.Model;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
