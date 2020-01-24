using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace KompasObj
{
    public class Kompas
    {
        HtmlDocument htmlPage;
        public Kompas(string url)
        {
            HtmlWeb page = new HtmlWeb();
            htmlPage = page.Load(url);
        }

        public List<List<string>> GetHeadLInes()
        {
            List<List<string>> ret = new List<List<string>>();
            var obj = htmlPage.DocumentNode.SelectNodes("//a[@class='headline__thumb__link']");
            foreach (var item in obj)
            {
                var link = item.GetAttributeValue("href", string.Empty);
                // var title = item.SelectNodes("//h2[@class='headline__thumb__title']")[0].InnerHtml;
                var title = item.InnerText;
                ret.Add(new List<string>{title, link});
            }
            

            return ret;
        }
    }
}