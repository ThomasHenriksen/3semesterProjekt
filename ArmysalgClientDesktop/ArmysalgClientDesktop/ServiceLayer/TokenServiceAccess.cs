using ArmysalgClientDesktop.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ServiceLayer
{
    public class TokenServiceAccess
    {
        readonly HttpClient _client;
        static readonly string restUrl = "http://localhost:50902";

        public TokenServiceAccess()
        {
            _client = new HttpClient();
        }

        //Retive a new Token from Api Service
        public async Task<string> GetNewToken(ApiAccount accountToUse)
        {
            string retrievedToken;
            /* Create elements for HTTP request */
            string useRestUrl = restUrl + "/" + "token";
            var uriToken = new Uri(string.Format(useRestUrl));
            /* Provide username, password and grant_type for the authentication. Content (body data) are posted in */
            HttpContent appAdminLogin = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grantType", accountToUse.GrantType),
                new KeyValuePair<string, string>("username", accountToUse.Username),
                new KeyValuePair<string, string>("password", accountToUse.Password)
                });
            /* Assemble HTTP request */
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uriToken,
                Content = appAdminLogin
            };
            /* Call service */
            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                retrievedToken = await response.Content.ReadAsStringAsync();
            }
            catch
            {
                retrievedToken = null;
            }
            return retrievedToken;
        }
    }
}