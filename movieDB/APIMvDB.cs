using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using MovieObj;


namespace APIMvBD
{
    public class API
    {
        private string apiKey;
        public API(string apiKey)
        {
            this.apiKey = apiKey; 
        }
        
        private async Task<string> reqObj(string url, HttpMethod methode)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(methode, url);
            HttpResponseMessage response = await client.SendAsync(req);
            return await response.Content.ReadAsStringAsync();
        }

        public List<string> GetMovieByCountry(string country)
        {
            string url = "https://api.themoviedb.org/3/search/movie?api_key="+apiKey+"&query="+ country + "&page=1&include_adult=True";
            string rawJson = reqObj(url, HttpMethod.Get).Result;
            MovieResult1 obj = JsonConvert.DeserializeObject<MovieResult1>(rawJson);
            var ret = from res in obj.results select res.original_title;
            return ret.ToList();
        }

        public int GetPlayerID(string player)
        {
            string url1 = "https://api.themoviedb.org/3/search/multi?api_key="+apiKey+"&language=en-US&query="+player.Replace(" ", "%20")+"&page=1&include_adult=false";
            string playerInfoJson = reqObj(url1, HttpMethod.Get).Result;
            Player playerInfo = JsonConvert.DeserializeObject<Player>(playerInfoJson);
            return playerInfo.GetID();
        }

        public List<string> GetMovieByPlayer(params string[] player)
        {
            List<string> players = new List<string>();
            for(int i=0; i<player.Length; i++)
                players.Add(GetPlayerID(player[i].Replace(" ", "%20")).ToString());

            string plyToSend = string.Join("%2C", players);
            string url = "https://api.themoviedb.org/3/discover/movie?api_key="+apiKey+"&language=en-US&region=US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&with_cast="+plyToSend;
            string rawJson = reqObj(url, HttpMethod.Get).Result;
            MovieResult1 obj = JsonConvert.DeserializeObject<MovieResult1>(rawJson);
            var ret = from res in obj.results select res.original_title;
            return ret.ToList();
        }

        public List<string> GetMovieByYearVote(int year, float vote)
        {
            string url = "https://api.themoviedb.org/3/discover/movie?api_key="+apiKey+"&sort_by=popularity.desc&page=1&primary_release_year="+year.ToString()+"&vote_count.gte="+vote.ToString();
            string rawJson = reqObj(url, HttpMethod.Get).Result;
            MovieResult1 obj = JsonConvert.DeserializeObject<MovieResult1>(rawJson);
            var ret = from res in obj.results select res.original_title;
            return ret.ToList();
        }


    }
}