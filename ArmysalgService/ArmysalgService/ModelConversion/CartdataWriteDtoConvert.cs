using ArmysalgDataAccess.ModelLayer;
using ArmysalgService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.ModelConversion
{
    public class CartdataWriteDtoConvert
    {
        public static Cart ToCart(CartdataWriteDto inDto)
        {
            Cart aCart = null;
            if (inDto != null)
            {
                aCart = new Cart(inDto.LastUpdated);
            }
            return aCart;
        }
    }
}
