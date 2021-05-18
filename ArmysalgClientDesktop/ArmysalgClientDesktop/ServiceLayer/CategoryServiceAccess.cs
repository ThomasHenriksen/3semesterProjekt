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
    class CategoryServiceAccess
    {
        static readonly string restUrl = "http://localhost:50902/api/categories";
        static readonly string authenType = "Bearer";
        readonly HttpClient _httpClient;

        public CategoryServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        public HttpStatusCode CurrentHttpStatusCode { get; set; }

        // Find and return all categorie objects.
        /// <summary>
        /// Find and return all categories objects.
        /// </summary>
        /// <returns>
        /// A list of category objects.
        /// </returns>
        /// <param name="tokenToUse">Jwt Token.</param>
        public async Task<List<Category>> GetAllCategories(string tokenToUse)
        {
            List<Category> categoriesFromService = null;
            //api/categories
            string useRestUrl = restUrl;

            var uri = new Uri(String.Format(useRestUrl));

            // Must add Bearer token to request header
            string bearerTokenValue = authenType + " " + tokenToUse;
            _httpClient.DefaultRequestHeaders.Remove("Authorization");          // To avoid more Authorization headers
            _httpClient.DefaultRequestHeaders.Add("Authorization", bearerTokenValue);

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
