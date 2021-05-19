using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.BusinessLogicLayer
{
    public class CustomerLogic
    {
        CustomerService _cAccess;
        public CustomerLogic()
        {
            _cAccess = new CustomerService();
        }
        // Method to retrieve all customers.
        /// <summary>
        /// Method to retrieve all customers.
        /// </summary>
        /// <returns>
        /// list of Customers object.
        /// </returns>
        /// <param name="CustomerNo">Customer Number.</param>
        public async Task<List<Customer>> GetAllCustomer()
        {
            List<Customer> foundCustomers = await _cAccess.GetCustomers();
            return foundCustomers;
        }

        // Method to retrieve a customer by customerEmail.
        /// <summary>
        /// Method to retrieve a customer by customerEmail.
        /// </summary>
        /// <returns>
        /// Customers object.
        /// </returns>
        /// <param name="customerEmail">customer email.</param>
        public async Task<Customer> GetCustomerByEmail(string customerEmail)
        {
            Customer foundCustomer = await _cAccess.GetCustomerByEmail(customerEmail);
            return foundCustomer;
        }
        // Method to save a customer.
        /// <summary>
        /// Method to save a customer.
        /// </summary>
        /// <returns>
        /// int 
        /// </returns>
        /// <param name="customerToSave">customer object.</param>
        public async Task<int> SaveCustomer(Customer newCustomer)
        {
            return await _cAccess.SaveCustomer(newCustomer);
        }
    }
}