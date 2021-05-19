using ArmysalgClientDesktop.ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ServiceLayer
{
    public class ProductServiceAccess
    {
        static readonly string restUrl = "http://localhost:50902/api/products";
        static readonly string authenType = "Bearer";
        readonly HttpClient _httpClient;

        public ProductServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        public HttpStatusCode CurrentHttpStatusCode { get; set; }

        //  Find and return products.
        /// <summary>
        /// Find and return products.
        /// </summary>
        /// <returns>
        /// List of product.
        /// </returns>
        /// <param name="tokenToUse">Jwt Token.</param>
        /// <param name="id"></param>
        public async Task<List<Product>> GetProducts(string tokenToUse, int id = -1)
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

            // Must add Bearer token to request header
            string bearerTokenValue = authenType + " " + tokenToUse;
            _httpClient.DefaultRequestHeaders.Remove("Authorization");          // To avoid more Authorization headers
            _httpClient.DefaultRequestHeaders.Add("Authorization", bearerTokenValue);

            try
            {
                var response = await _httpClient.GetAsync(uri);
                CurrentHttpStatusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
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

        //  Save a new product object.
        /// <summary>
        /// Save a new product object.
        /// </summary>
        /// <returns>
        /// Product number on saved product object.
        /// </returns>
        /// <param name="productToSave">Product object.</param>
        /// <param name="tokenToUse">Jwt Token</param>
        public async Task<int> SaveProduct(Product productToSave, string tokenToUse)
        {
            int insertedProductId;

            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            // Must add Bearer token to request header
            string bearerTokenValue = authenType + " " + tokenToUse;
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", bearerTokenValue);

            try
            {
                var json = JsonConvert.SerializeObject(productToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);

                CurrentHttpStatusCode = response.StatusCode;
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
