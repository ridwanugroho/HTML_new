using System;
using KompasObj;

namespace Scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://kompas.com";
            Kompas kompas = new Kompas(url);
            var headline = kompas.GetHeadLInes();
            Console.WriteLine("hedline kompas.com hari ini :");
            foreach(var i in headline)
                Console.WriteLine($"tittle : {i[0]}\nLink : {i[1]}\n");
        }       
    }
}
