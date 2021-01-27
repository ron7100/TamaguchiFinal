using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UILevel.DataTransferObjects;

namespace UILevel.WebServices
{
    class WebApi
    {
        private HttpClient client;
        private string baseUrl;
        public WebApi(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.CookieContainer = new System.Net.CookieContainer();

            this.client = new HttpClient(clientHandler, true);
            this.baseUrl = url;
        }
        public async Task<PlayerDTO> sign_in_async(string username, string password)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUrl}/SignIn?email={username}&pass={password}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(content, options);
                    return p;
                }
                else
                {
                    Console.WriteLine("Something Went Wrong...");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("oops! " + e.Message);
                return null;
            }
        }
    }
}
