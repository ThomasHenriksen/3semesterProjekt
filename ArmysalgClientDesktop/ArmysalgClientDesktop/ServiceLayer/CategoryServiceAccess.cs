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
    class CategoryServiceAccess
    {
        static readonly string restUrl = "http://localhost:50902/api/category";
        readonly HttpClient _httpClient;

        public CategoryServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> categoriesFromService = null;
            //api/categories
            string useRestUrl = restUrl;

            var uri = new Uri(String.Format(useRestUrl));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    categoriesFromService = JsonConvert.DeserializeObject<List<Category>>(content); 
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        categoriesFromService = null;
                    }
                }
            }
            catch
            {
                categoriesFromService = null;
            }
            return categoriesFromService;
        }
    }
}
