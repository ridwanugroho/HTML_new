using System;
using System.Threading.Tasks;
using System.Net.Http;
using FetcherSys;

namespace FetcherProg
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Fetcher f = new Fetcher();
            Console.WriteLine("GET : \n{0}", await f.Get("https://httpbin.org/get"));
            Console.WriteLine("DELETE : \n{0}", await f.Delete("https://httpbin.org/delete"));
            var jsonData = @"
  {
    ""id"": 30,
    ""name"": ""Someone""
  }
";
            
            Console.WriteLine("POST : \n{0}", await f.Post("https://httpbin.org/post", jsonData));
            Console.WriteLine("PUT : \n{0}", await f.Put("https://httpbin.org/put", jsonData));
            Console.WriteLine("PATCH : \n{0}", await f.Patch("https://httpbin.org/patch", jsonData));
        }
    }
}
