using ArmysalgDataAccess.Model;

namespace ArmysalgDataAccess.Database
{
    public interface ICustomerDatabaseAccess
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
        Customer GetCustomerByCustomerNo(int customerNo);

        // Find and return customer from database by customer email.
        /// <summary>
        /// Find and return customer from database by customer email.
        /// </summary>
        /// <returns>
        /// Customer object.
        /// </returns>
        /// <param name="customerEmail">Customer email.</param>
        Customer GetCustomerByCustomerEmail(string findCustomerEmail);

        // Delete customer from database based on customer number.
        /// <summary>
        /// Delete customer from database based on customer number.
        /// </summary>
        /// <returns>
        /// Bool statement whether customer was deleted or not.
        /// </returns>
        /// <param name="customerNo">Customer number.</param>
        bool DeleteCustomerByCustomerNo(int customerNo);

        // Checks if customer has AspNetUser by comparing email parameter.
        /// <summary>
        /// Checks if customer has AspNetUser by comparing email parameter.
        /// </summary>
        /// <returns>
        /// Bool statement whether customer has AspNetUser or not.
        /// </returns>
        /// <param name="aCustomer">Customer object.</param>
        bool CustomerHasAspNetUser(Customer aCustomer);

        // Connects customer to AspNetUser in database.
        /// <summary>
        /// Connects customer to AspNetUser in database.
        /// </summary>
        /// <param name="aCustomer">Customer object.</param>
        void ConnectCustomerToAspNetUser(Customer aCustomer);
    }
}
