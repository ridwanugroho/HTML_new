using System;
using APIMvBD;

namespace movieDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string APIKey = "5931d9282810996c3a67c0c6529068b7";
            API api = new API(APIKey);
            separator("Indonesian movies : ");
            foreach(var t in  api.GetMovieByCountry("Indonesia"))
                Console.WriteLine(t);
            
            separator("played by Keanu Reeves : ");
            foreach(var t in api.GetMovieByPlayer("Keanu reeves"))
                Console.WriteLine(t);

            separator("played by Robert Downey Jr Tom Holland : ");
            foreach(var t in api.GetMovieByPlayer("Robert Downey Jr", "Tom Holland"))
                Console.WriteLine(t);

            separator("popuar movies in 2016 and voted above 7.5 :");
            foreach (var t in api.GetMovieByYearVote(2016, (float)7.5))
                Console.WriteLine(t);
        }

        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }
    }
}
