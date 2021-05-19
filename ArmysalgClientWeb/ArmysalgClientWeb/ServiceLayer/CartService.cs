using ArmysalgClientWeb.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.ServiceLayer
{
    public class CartService
    {

        static readonly string restUrl = "http://localhost:50902/api/cart";
        readonly HttpClient _httpClient;
        public CartService()
        {
            _httpClient = new HttpClient();
        }

        // Find and return cart from database by CustomerNo.
        /// <summary>
        /// Find and return cart from database by CustomerNo.
        /// </summary>
        /// <returns>
        /// Cart object.
        /// </returns>
        /// <param name="CustomerNo">Customer Number.</param>
        public async Task<Cart> GetCartByCustomerNo(int CustomerNo)
        {
            Cart cartFromService = null;

            string useRestUrl = restUrl;
            bool hasValidId = (CustomerNo > 0);
            if (hasValidId)
            {
                useRestUrl += "/" + CustomerNo;
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
                        cartFromService = JsonConvert.DeserializeObject<Cart>(content);
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    cartFromService = null;
                }
            }
            catch
            {
                cartFromService = null;
            }
            return cartFromService;
        }
        // Update cart in the database.
        /// <summary>
        /// Update cart in the database.
        /// </summary>
        /// <returns>
        /// Bool statement whether cart was deleted or not.
        /// </returns>
        /// <param name="aCart">Cart object.</param>
        public async Task<bool> UpdateCart(Cart cartToUpdate)
        {
            bool updatedOk;

            string useRestUrl = restUrl;

            var uri = new Uri(string.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(cartToUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    updatedOk = true;
                }
                else
                {
                    updatedOk = false;
                }
            }
            catch
            {
                updatedOk = false;
            }

            return updatedOk;
        }
    }
}
