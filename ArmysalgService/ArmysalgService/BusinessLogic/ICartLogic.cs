using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface ICartLogic
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
        int AddCart(Cart aCart, Customer customer);

        // Find and return cart from database by cart object.
        /// <summary>
        /// Find and return cart from database by cart object.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="aCustomer">Customer object.</param>
        Cart GetCart(Customer aCustomer);

        // Update cart in the database.
        /// <summary>
        /// Update cart in the database.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="aCart">Cart object.</param>
        Cart UpdateCart(Cart aCart);

        // Delete cart from database based on cart ID.
        /// <summary>
        /// Delete cart from database based on cart ID.
        /// </summary>
        /// <returns>
        /// Bool statement whether cart was deleted or not.
        /// </returns>
        /// <param name="cartId">Cart ID</param>
        bool DeleteCart(int cartId);
    }
}
