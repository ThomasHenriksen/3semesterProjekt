using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ICartDatabaseAccess
    {
        // Add cart to the database.
        /// <summary>
        /// Add cart to the database.
        /// </summary>
        /// <returns>
        /// Cart ID of inserted cart object.
        /// </returns>
        /// <param name="aCart">Cart object.</param>
        /// <param name="aCustomer">Customer object.</param>
        int AddCart(Cart aCart, Customer aCustomer);

        // Find and return cart from database by cart ID.
        /// <summary>
        /// Find and return cart from database by cart ID.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="cartId">Cart ID.</param>
        Cart GetCartById(int cartId);

        // Find and return cart from database by cart number.
        /// <summary>
        /// Find and return cart from database by cart number.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="customerNo">Customer number.</param>
        Cart GetCartByCustomerNo(int CustomerNo);

        // Update cart in the database.
        /// <summary>
        /// Update cart in the database.
        /// </summary>
        /// <returns>
        /// Bool statement whether cart was updated or not.
        /// </returns>
        /// <param name="cartId">Cart ID.</param>
        bool UpdateCart(Cart aCart);

        // Delete cart from database based on cart ID.
        /// <summary>
        /// Delete cart from database based on cart ID.
        /// </summary>
        /// <returns>
        /// Bool statement whether cart was deleted or not.
        /// </returns>
        /// <param name="cartId">Cart ID</param>
        bool DeleteCartByCartId(int cartId);
    }
}
