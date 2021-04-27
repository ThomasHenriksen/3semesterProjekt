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
        ICartDatabaseAccess _cartAccess;

        public CustomerLogic(IConfiguration inConfiguration)
        {
            _customerAccess = new CustomerDatabaseAccess(inConfiguration);
            _cartAccess = new CartDatabaseAccess(inConfiguration);
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

                //Connect customer to AspNetUser and a new cart if customer has AspNetUser
                if (_customerAccess.CustomerHasAspNetUser(newCustomer))
                {
                    newCustomer.CustomerNo = insertedCustomerNo;
                    AddWebUserPropertiesToCustomer(newCustomer);
                }
            }
            catch
            {
                insertedCustomerNo = -1;
            }
            return insertedCustomerNo;
        }

       /*
        *  Connect customer to AspNetUser and a new cart
        *  @param customer
        *  
        *  @return wasAdded
        */
        public bool AddWebUserPropertiesToCustomer(Customer customer)
        {
            bool wasAdded;

            try
            {
                //Connect customer to AspNetUser
                _customerAccess.ConnectCustomerToAspNetUser(customer);

                //Create and add new cart to customer
                Cart newCart = new Cart(customer);
                _cartAccess.CreateCart(newCart);

                wasAdded = true;
            }
            catch
            {
                wasAdded = false;
            }
            return wasAdded;
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
    }
}
