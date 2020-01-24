using System;
using System.Collections.Generic;

namespace MovieObj
{
    public class MovieResult1
    {
        public int page{get; set;}
        public int total_results{get; set;}
        public int total_pages{get; set;}
        public List<Result1> results{get; set;}
    }

    public class Result1
    {
        public float popularity{get; set;}
        public int id{get; set;}
        public bool video{get; set;}
        public int vote_count{get; set;}
        public float vote_average{get; set;}
        public string title{get; set;}
        public DateTime release_date{get; set;}
        public string orignal_language{get; set;}
        public string original_title{get; set;}
        public int[] genre_ids{get; set;}
        public string backdrop_path{get; set;}
        public bool adult{get; set;}
        public string overview{get; set;}
        public string poster_path{get; set;}
    }

    public class Player
    {
        public class Result
        {
            public int id{get; set;}
        }

        public List<Result> results{get; set;}

        public int GetID(){return results[0].id;}
    }
}