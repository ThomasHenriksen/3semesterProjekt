using ArmysalgClientWeb.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientWeb.ServiceLayer
{
    public class ShippingService
    {
        static readonly string restUrl = "http://localhost:50902/api/shippings/";
        readonly HttpClient _client;


        public ShippingService()
        {
            _client = new HttpClient();
        }
        // Method to save a Shipping.
        /// <summary>
        /// Method to save a Shipping.
        /// </summary>
        /// <returns>
        /// int 
        /// </returns>
        /// <param name="shippingToSave">Shipping object.</param>
        public async Task<int> SaveShipping(Shipping shippingToSave)
        {
            int insertedShippingID;
            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(shippingToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                string resultShippingID = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultShippingID, out insertedShippingID);
                }
                else
                {
                    insertedShippingID = -2;
                }
            }
            catch
            {
                insertedShippingID = -3;
            }

            return insertedShippingID;
        }
    }
}