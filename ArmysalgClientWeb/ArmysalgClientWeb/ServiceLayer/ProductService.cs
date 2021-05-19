using ArmysalgClientWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.ServiceLayer
{
    public class ProductService
    {
        static readonly string restUrl = "http://localhost:50902/api/products";
        readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        // Method to retrieve all products.
        /// <summary>
        /// Method to retrieve all products.
        /// </summary>
        /// <returns>
        /// list of product object.
        /// </returns>
        /// <param name="id">Product id.</param>
        public async Task<List<Product>> GetProducts()
        {
            List<Product> productFromService = null;

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
                        Product foundProduct = JsonConvert.DeserializeObject<Product>(content);
                        if (foundProduct != null)
                        {
                            productFromService = new List<Product>() { foundProduct };
                        }
                    }
                    else
                    {
                        productFromService = JsonConvert.DeserializeObject<List<Product>>(content);
                    }
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        productFromService = new List<Product>();
                    }
                    else
                    {
                        productFromService = null;
                    }
                }
            }
            catch
            {
                productFromService = null;
            }
            return productFromService;
        }
        // Method to retrieve a product by id.
        /// <summary>
        /// Method to retrieve a product by id.
        /// </summary>
        /// <returns>
        /// product object.
        /// </returns>
        /// <param name="id">Product id.</param>
        public async Task<Product> GetProduct(int id)
        {
            Product productFromService = null;

            string useRestUrl = restUrl;
            bool hasValidId = (id > 0);
            if (hasValidId)
            {
                useRestUrl += "/" + id;
            }
            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (hasValidId)
                    {
                        productFromService = JsonConvert.DeserializeObject<Product>(content);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    productFromService = null;
                }
            }
            catch
            {
                productFromService = null;
            }
            return productFromService;
        }
    }
}
