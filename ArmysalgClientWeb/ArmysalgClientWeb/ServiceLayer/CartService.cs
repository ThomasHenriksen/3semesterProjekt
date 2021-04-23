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

        public async Task<int> SaveCart(Cart cartToSave)
        {
            int insertedcartId;
            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(cartToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedcartId);
                }
                else
                {
                    insertedcartId = -2;
                }
            }
            catch
            {
                insertedcartId = -3;
            }

            return insertedcartId;
        }
    }
}
