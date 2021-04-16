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
    public class SalesOrderService
    {
        static readonly string restUrl = "http://localhost:50902/api/salesOrders/";
        readonly HttpClient _client;

       
        public SalesOrderService()
        {
            _client = new HttpClient();
        }

        public async Task<int> SaveSalesOrder(SalesOrder salesOrderToSave)
        {
            int insertedSalesOrderNo;
            string useRestUrl = restUrl;
            var uri = new Uri(String.Format(useRestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(salesOrderToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                string resultSalesNo = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Int32.TryParse(resultSalesNo, out insertedSalesOrderNo);
                }
                else
                {
                    insertedSalesOrderNo = -2;
                }
            }
            catch 
            {
                insertedSalesOrderNo = -3;
            }

            return insertedSalesOrderNo;
        }
    }
}
