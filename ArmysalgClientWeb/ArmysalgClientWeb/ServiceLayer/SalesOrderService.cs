using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
