using ArmysalgDataAccess.Model;

namespace ArmysalgService.BusinessLogic
{
    public interface ICustomerLogic
    {
        // Add customer to the database.
        /// <summary>
        /// Add customer to the database.
        /// </summary>
        /// <returns>
        /// Customer number of inserted customer object.
        /// </returns>
        /// <param name="aCustomer">Customer object.</param>
        int AddCustomer(Customer aCustomer);

        // Find and return customer from database by customer number.
        /// <summary>
        /// Find and return customer from database by customer number.
        /// </summary>
        /// <returns>
        /// Customer object.
        /// </returns>
        /// <param name="customerNo">Customer number.</param>
        Customer GetCustomer(int customerNo);

        // Find and return customer from database by customer email.
        /// <summary>
        /// Find and return customer from database by customer email.
        /// </summary>
        /// <returns>
        /// Customer object.
        /// </returns>
        /// <param name="customerEmail">Customer email.</param>
        Customer GetCustomer(string customerEmail);
    }
}
