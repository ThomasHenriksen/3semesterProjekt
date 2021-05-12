using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;

namespace ArmysalgService.BusinessLogic
{
    public class CartLogic : ICartLogic
    {
        ICartDatabaseAccess _cartDatabaseAccess;
        ISalesLineItemDatabaseAcces _salesLineItemDatabaseAccess;

        public CartLogic(IConfiguration inConfiguration)
        {
            _cartDatabaseAccess = new CartDatabaseAccess(inConfiguration);
            _salesLineItemDatabaseAccess = new SalesLineItemDatabaseAccess(inConfiguration);
        }

        // Add cart to the database.
        /// <inheritdoc/>
        public int AddCart(Cart aCart, Customer aCustomer)
        {
            int insertedId;

            try
            {
                insertedId = _cartDatabaseAccess.AddCart(aCart, aCustomer);
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }

        // Find and return cart from database by customer object.
        /// <inheritdoc/>
        public Cart GetCart(Customer aCustomer)
        {
            return _cartDatabaseAccess.GetCartByCustomerNo(aCustomer.CustomerNo);
        }

        // Update cart in the database.
        /// <inheritdoc/>
        public Cart UpdateCart(Cart aCart)
        {

            foreach (SalesLineItem salesLineItem in aCart.SalesLineItems)
            {
                if (_salesLineItemDatabaseAccess.CheckSalesLineItem(salesLineItem, aCart))
                {
                    _salesLineItemDatabaseAccess.UpdateSalesLineItem(salesLineItem, aCart, null);
                    _cartDatabaseAccess.UpdateCart(aCart);

                }
                else
                {
                    _salesLineItemDatabaseAccess.AddSalesLineItem(salesLineItem, aCart);
                }
            }
            return aCart;
        }

        // Delete cart from database based on cart ID.
        /// <inheritdoc/>
        public bool DeleteCart(int cartId)
        {
            return _cartDatabaseAccess.DeleteCartByCartId(cartId);
        }
    }
}
