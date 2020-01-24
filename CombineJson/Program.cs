using System;
using System.IO;
using CombineUsrArt;


namespace CombineJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "https://jsonplaceholder.typicode.com/posts";
            string user = "https://jsonplaceholder.typicode.com/users";
            var combine = new Combine(user, post);

            string json = combine.CombineAll();
            TextWriter tw = new StreamWriter("D:/json.json");
            foreach (var s in json)
                tw.Write(s);
            
            tw.Close();
        }
    }
}
