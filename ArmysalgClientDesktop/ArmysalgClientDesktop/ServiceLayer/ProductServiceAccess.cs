using ArmysalgClientDesktop.ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ServiceLayer
{
    public class ProductServiceAccess
    {
        static readonly string restUrl = "http://localhost:50902/api/products";
        readonly HttpClient _httpClient;

        public ProductServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        /* Method to retrieve Products 
         */
        public async Task<List<Product>> GetProducts(int id = -1)
        {
            List<Product> productFromService = null;

            // api/persons/{id}
            string useRestUrl = restUrl;
            bool hasValidId = (id > 0);
            if (hasValidId)
            {
                useRestUrl += id;
            }
            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if(hasValidId)
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

        public async Task<int> SaveProduct(Product productToSave)
        {
            int insertedProductId;

            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(productToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedProductId);
                }
                else
                {
                    insertedProductId = -2;
                }
            }
            catch 
            {
                insertedProductId = -3;
            }
            return insertedProductId;
        }
    }
}
