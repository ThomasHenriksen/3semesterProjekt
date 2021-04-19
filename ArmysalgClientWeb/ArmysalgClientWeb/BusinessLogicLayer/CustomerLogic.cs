using ArmysalgClientWeb.Models;
using ArmysalgClientWeb.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Customer>> GetAllCustomer()
        {
            List<Customer> foundCustomers = await _cAccess.GetCustomers();
            return foundCustomers;
        }
        public async Task<int> SaveCustomer(string firstName, string lastName, string address, string zipCode, string city, string phone, string email)
        {
            Customer newCustomer = new Customer(firstName, lastName, address, zipCode, city, phone, email);
            return await _cAccess.SaveCustomer(newCustomer);
        }
    }
}
