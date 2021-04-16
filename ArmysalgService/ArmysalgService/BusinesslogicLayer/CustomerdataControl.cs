using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ArmysalgDataAccess.DatabaseLayer;
using ArmysalgDataAccess.ModelLayer;

namespace ArmysalgService.BusinesslogicLayer
{
    public class CustomerdataControl : ICustomerdata
    {
        ICustomerAccess _customerAccess;

        public CustomerdataControl(IConfiguration inConfiguration)
        {
            _customerAccess = new CustomerDatabaseAccess(inConfiguration);
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
    }
}
