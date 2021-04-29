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
    public class SupplierServiceAccess
    {
        static readonly string restUrl = "http://localhost:50902/api/suppliers";
        readonly HttpClient _httpClient;

        public SupplierServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        /* 
         * Method to save an Supplier
         */
        public async Task<int> SaveSupplier(Supplier supplierToSave)
        {
            int insertedSupplierId;

            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(supplierToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);
                string resultingIdString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultingIdString, out insertedSupplierId);
                }
                else
                {
                    insertedSupplierId = -2;
                }
            }
            catch
            {
                insertedSupplierId = -3;
            }
            return insertedSupplierId;
        }
    }
}
