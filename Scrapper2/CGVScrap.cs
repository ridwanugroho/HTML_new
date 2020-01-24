using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using PuppeteerSharp;
using HtmlAgilityPack;

namespace CGVScrapper
{
    public class CGV
    {
        public async  Task<List<Movie>> start()
        {
            List<Movie> ret = new List<Movie>();
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            var page = await browser.NewPageAsync();
            var htmlPage = await page.GoToAsync("https://www.cgv.id/en/movies/now_playing");
            var res = await page.QuerySelectorAllHandleAsync(".movie-list-body > ul > li > a")
                        .EvaluateFunctionAsync<string[]>("e => e.map(a => a.href)");
            foreach(var link in res)
                ret.Add(getContent(link));
            
            await browser.CloseAsync();

            // PropertyInfo[] prop = typeof(Movie).GetProperties();
            // foreach (var pro in prop)
            // {
            //     Console.WriteLine(pro.Name);
            // }

            return ret;
        }

        private Movie getContent(string url)
        {
            Movie temp = new Movie();
            HtmlWeb page = new HtmlWeb();
            HtmlDocument htmlPage = page.Load(url);
            temp.title = htmlPage.DocumentNode.SelectSingleNode("//div[@class='movie-info-title']")
                        .InnerHtml.ToString().Trim();
            
            var info = htmlPage.DocumentNode.SelectNodes("//div[@class='movie-add-info left']/ul/li");
            PropertyInfo[] props = typeof(Movie).GetProperties();
            foreach(var li in info)
            {
                foreach (var prop in props)
                {
                    if(Contain(li.InnerText, prop.Name))
                    {
                        prop.SetValue(temp, li.InnerText.Trim().Substring(li.InnerText.IndexOf(" :")+3));
                    }
                }
            }

            temp.trailer_link = htmlPage.DocumentNode.SelectSingleNode("//div[@class='trailer-btn-wrapper']/img")
                                .GetAttributeValue("onclick", string.Empty).Split("'")[1];
            temp.synopsis = htmlPage.DocumentNode.SelectSingleNode("//div[@class='movie-synopsis right']").InnerText.Trim();
            
            
            return temp;

        }

        public static bool Contain(string source, string value)
        {
            var clt = new CultureInfo("en-US");
            return clt.CompareInfo.IndexOf(source, value, CompareOptions.IgnoreCase) >= 0;
        }
    }

    public class Movie
    {
        public string title{get; set;}
        public string starring{get; set;}
        public string director{get; set;}
        public string censor_rating{get; set;}
        public string genre{get; set;}
        public string language{get; set;}
        public string subtitle{get; set;}
        public string duration{get; set;}
        public string trailer_link{get; set;}
        public string synopsis{get; set;}
        
    }
}