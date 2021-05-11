using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;

namespace ArmysalgService.BusinessLogic
{
    public class CustomerLogic : ICustomerLogic
    {
        ICustomerDatabaseAccess _customerAccess;
        ICartLogic _cartLogic;

        public CustomerLogic(IConfiguration inConfiguration)
        {
            _customerAccess = new CustomerDatabaseAccess(inConfiguration);
            _cartLogic = new CartLogic(inConfiguration);
        }

        // Add a new customer in the database.
        /// <inheritdoc/>
        public int AddCustomer(Customer addCustomer)
        {
            int insertedCustomerNo;

            try
            {
                insertedCustomerNo = _customerAccess.AddCustomer(addCustomer);
                addCustomer.CustomerNo = insertedCustomerNo;

                //Add cart to customer
                if (addCustomer.Cart != null)
                {
                    _cartLogic.AddCart(addCustomer.Cart, addCustomer);
                }

                //Add customer to AspNetUser
                if (_customerAccess.CustomerHasAspNetUser(addCustomer))
                {
                    _customerAccess.ConnectCustomerToAspNetUser(addCustomer);
                }
            }
            catch
            {
                insertedCustomerNo = -1;
            }
            return insertedCustomerNo;
        }

        // Find and return customer from database by customer number.
        /// <inheritdoc/>
        public Customer GetCustomerByCustomerNo(int customerNo)
        {
            Customer foundCustomer;
            try
            {
                foundCustomer = _customerAccess.GetCustomerByCustomerNo(customerNo);
            }
            catch
            {
                foundCustomer = null;
            }
            return foundCustomer;
        }

        // Find and return customer from database by customer email.
        /// <inheritdoc/>
        public Customer GetCustomerByCustomerMail(string customerEmail)
        {
            Customer foundCustomer;
            try
            {
                foundCustomer = _customerAccess.GetCustomerByCustomerEmail(customerEmail);
            }
            catch 
            {
                foundCustomer = null;
            }
            return foundCustomer;
        }
    }
}