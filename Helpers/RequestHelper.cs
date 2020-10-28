using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ForEagle.Helpers
{
    class RequestHelper
    {
        protected HttpClient Client { get; set; }

        public RequestHelper()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            Client = new HttpClient(handler);
        }

        public async Task<string> GetRequest(string uri)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var responce = await Client.SendAsync(request);
            var content = await responce.Content.ReadAsStringAsync();
            return content;
        }

    }
}
