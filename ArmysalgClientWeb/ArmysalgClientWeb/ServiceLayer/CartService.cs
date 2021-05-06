using ArmysalgClientWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.ServiceLayer
{
    public class CartService
    {

        static readonly string restUrl = "http://localhost:50902/api/carts";
        readonly HttpClient _httpClient;
        public CartService()
        {
            _httpClient = new HttpClient();
        }

        /* Method to retrieve all Products in customers cart
         */
        public async Task<Cart> GetCartByCustomerNo(int CustomerNo)
        {
            Cart cartFromService = null;

            string useRestUrl = restUrl;
            bool hasValidId = (CustomerNo > 0);
            if (hasValidId)
            {
                useRestUrl += CustomerNo;
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
    }
}
