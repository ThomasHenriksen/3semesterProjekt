using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmysalgService.BusinesslogicLayer
{
    public class CartdataControl : ICartdata
    {
        ICartDatabaseAccess _cartAccess;

        public CartdataControl(IConfiguration inConfiguration)
        {
            _cartAccess = new CartDatabaseAccess(inConfiguration);
        }

        public int AddCart(Cart cartToAdd)
        {
            int insertedId;

            try
            {
                insertedId = _cartAccess.CreateCart(cartToAdd);
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
