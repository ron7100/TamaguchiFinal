using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

    }
}
