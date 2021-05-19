using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
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
        // Find and return cart from database by CustomerNo.
        /// <summary>
        /// Find and return cart from database by CustomerNo.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="CustomerNo">Customer Number.</param>
        public async Task<Cart> GetCartByCustomerNo(int CustomerNo)
        {
            Cart foundCart = await _cAccess.GetCartByCustomerNo(CustomerNo);
            return foundCart;
        }
        // Update cart in the database.
        /// <summary>
        /// Update cart in the database.
        /// </summary>
        /// <returns>
        /// Bool statement whether cart was deleted or not.
        /// </returns>
        /// <param name="aCart">Cart object.</param>
        public async Task<bool> UpdateCart(Cart cart)
        {
            return await _cAccess.UpdateCart(cart);
        }
    }
}