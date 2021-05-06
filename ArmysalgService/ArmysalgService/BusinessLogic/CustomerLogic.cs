using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ArmysalgDataAccess.Database;
using ArmysalgDataAccess.Model;

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

        /*
         *  Create a new customer in the database
         *  @param newCustomer
         *  
         *  @return insertedCustomerNo
         */
        public int AddCustomer(Customer newCustomer)
        {
            int insertedCustomerNo;

            try
            {
                insertedCustomerNo = _customerAccess.CreateCustomer(newCustomer);
                newCustomer.CustomerNo = insertedCustomerNo;

                //Add cart to customer
                if (newCustomer.Cart != null)
                {
                    _cartLogic.AddCart(newCustomer.Cart, newCustomer);
                }
                
                //Add customer to AspNetUser
                if (_customerAccess.CustomerHasAspNetUser(newCustomer))
                {
                    _customerAccess.ConnectCustomerToAspNetUser(newCustomer);
                }
            }
            catch
            {
                insertedCustomerNo = -1;
            }
            return insertedCustomerNo;
        }

        /*
         *  Find a customer in the database by customerNo
         *  @param customerNoToMatch
         *  
         *  @return Customer
         */
        public Customer GetCustomer(int customerNoToMatch)
        {
            Customer foundCustomer;
            try
            {
                foundCustomer = _customerAccess.GetCustomerByCustomerNo(customerNoToMatch);
            }
            catch
            {
                foundCustomer = null;
            }
            return foundCustomer;
        }
        public Customer GetCustomer(string customerEmailToMatch)
        {
            Customer foundCustomer;
            try
            {
                foundCustomer = _customerAccess.GetCustomerByCustomerEmail(customerEmailToMatch);
            }
            catch(Exception e)
            {
                string test = e.ToString();
                foundCustomer = null;
            }
            return foundCustomer;
        }
    }
}
