using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using UserData;
using ArticlePost;

namespace CombineUsrArt
{
    public class Combine
    {
        private List<User> users;
        private List<Article> articles;

        public Combine(string url1, string url2)
        {
            users = JsonConvert.DeserializeObject<List<User>>(Fetch(url1).Result);
            articles = JsonConvert.DeserializeObject<List<Article>>(Fetch(url2).Result);
        }

        public async Task<string> Fetch(string url)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await client.SendAsync(req);
            return await response.Content.ReadAsStringAsync();
        }

        public string CombineAll()
        {
            List<Expected> exp = new List<Expected>();
            foreach (var post in articles)
            {
                foreach (var user in users)
                {
                    if(post.userId == user.id)
                    {
                        Expected temp = new Expected();
                        temp.userId = post.userId;
                        temp.id = post.id;
                        temp.title = post.title;
                        temp.body = post.body;
                        temp.user = user;

                        exp.Add(temp);
                    }
                }   
            }

            string outJson = JsonConvert.SerializeObject(exp, Formatting.Indented);
            return outJson;
        }
    }

    public class Expected
    {
        public int userId{get; set;}
        public int id{get; set;}
        public string title{get; set;}
        public string body{get; set;}
        public User user{get; set;}
    }
}