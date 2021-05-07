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
        public async Task<Cart> GetCartByCustomerNo(int CustomerNo)
        {
            Cart foundCart = await _cAccess.GetCartByCustomerNo(CustomerNo);
            return foundCart;
        }

        public async Task<bool> UpdateCart(Cart cart)
        {
            return await _cAccess.UpdateCart(cart);
        }
    }
}