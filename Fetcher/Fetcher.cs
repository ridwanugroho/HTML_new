using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace FetcherSys
{
    public class Fetcher
    {
        private async Task<string> ReqObj(string url, HttpMethod methode, string data="")
        {
            HttpClient client = new HttpClient();
            var stringCOntent = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            HttpRequestMessage req = new HttpRequestMessage(methode, url);
            req.Content = stringCOntent;
            HttpResponseMessage response = await client.SendAsync(req);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Get(string url)
        {
            return await ReqObj(url, HttpMethod.Get);
        }

        public async Task<string> Delete(string url)
        {
            return await ReqObj(url, HttpMethod.Delete);
        }

        public async Task<string> Post(string url, string data)
        {
            return await ReqObj(url, HttpMethod.Post, data);
        }

        public async Task<string> Put(string url, string data)
        {
            return await ReqObj(url, HttpMethod.Put, data);
        }

        public async Task<string> Patch(string url, string data)
        {
            return await ReqObj(url, HttpMethod.Patch, data);
        }

    }
}