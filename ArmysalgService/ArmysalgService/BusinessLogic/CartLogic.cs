using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinessLogic
{
    public class CartLogic : ICartLogic
    {
        ICartDatabaseAccess _cartAccess;

        public CartLogic(IConfiguration inConfiguration)
        {
            _cartAccess = new CartDatabaseAccess(inConfiguration);
        }

        public int AddCart(Cart cartToAdd, Customer customer)
        {
            int insertedId;

            try
            {
                insertedId = _cartAccess.CreateCart(cartToAdd, customer);
            }
            catch 
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool DeleteCart(int id)
        {
            return _cartAccess.DeleteCartByCartId(id);
        }

        public Cart GetCart(int id)
        {
            Cart foundCart;
            try
            {
                foundCart = _cartAccess.GetCartById(id);
            }
            catch 
            {
                foundCart = null;
            }
            return foundCart;
        }
    }
}
