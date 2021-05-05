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
    }
}
