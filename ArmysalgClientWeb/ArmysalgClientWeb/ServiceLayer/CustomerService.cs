using ArmysalgClientWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.ServiceLayer
{
    public class CustomerService
    {
        static readonly string restUrl = "http://localhost:50902/api/customers";
        readonly HttpClient _httpClient;
        public CustomerService()
        {
            _httpClient = new HttpClient();
        }
        // Method to retrieve all customers.
        /// <summary>
        /// Method to retrieve all customers.
        /// </summary>
        /// <returns>
        /// list of Customers object.
        /// </returns>
        /// <param name="CustomerNo">Customer Number.</param>
        public async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customerFromService = null;

            string useRestUrl = restUrl;
            bool hasValidId = false;

            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (hasValidId)
                    {
                        Customer foundCustomer = JsonConvert.DeserializeObject<Customer>(content);
                        if (foundCustomer != null)
                        {
                            customerFromService = new List<Customer>() { foundCustomer };
                        }
                    }
                    else
                    {
                        customerFromService = JsonConvert.DeserializeObject<List<Customer>>(content);
                    }
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        customerFromService = new List<Customer>();
                    }
                    else
                    {
                        customerFromService = null;
                    }
                }
            }
            catch
            {
                customerFromService = null;
            }
            return customerFromService;
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
            Customer customerFromService = null;

            string useRestUrl = restUrl;
            bool isValid = (customerEmail != null);
            if (isValid)
            {
                useRestUrl += "/" + customerEmail;
            }
            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (isValid)
                    {
                        customerFromService = JsonConvert.DeserializeObject<Customer>(content);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    customerFromService = null;
                }
            }
            catch
            {
                customerFromService = null;
            }
            return customerFromService;
        }
        // Method to save a customer.
        /// <summary>
        /// Method to save a customer.
        /// </summary>
        /// <returns>
        /// int 
        /// </returns>
        /// <param name="customerToSave">customer object.</param>
        public async Task<int> SaveCustomer(Customer customerToSave)
        {
            int insertedCustomerNo;
            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(customerToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedCustomerNo);
                }
                else
                {
                    insertedCustomerNo = -2;
                }
            }
            catch
            {
                insertedCustomerNo = -3;
            }

            return insertedCustomerNo;
        }
    }
}
