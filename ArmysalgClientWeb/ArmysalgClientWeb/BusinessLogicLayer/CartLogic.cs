using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.BusinessLogicLayer
{
    public class CartLogic
    {
        CartService _cAccess;
        public CartLogic()
        {
            _cAccess = new CartService();
        }

        public async Task<int> SaveCart(Cart newCart)
        {
            return await _cAccess.SaveCart(newCart);
        }
    }
}
