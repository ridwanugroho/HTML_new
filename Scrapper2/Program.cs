using System;
using System.Threading.Tasks;
using CGVScrapper;


namespace Scrapper2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CGV cgv = new CGV();
            var ret = await cgv.start();
            foreach (var item in ret)
            {
                Console.WriteLine(item.title + "\n");
                Console.WriteLine("Jenis Film : {0}", item.genre);
                Console.WriteLine("Produser : -");
                Console.WriteLine("Sutradara : -");
                Console.WriteLine("Penulis : -");
                Console.WriteLine("Director : {0}", item.director);
                Console.WriteLine("Produksi : -");
                Console.WriteLine("Casts : {0}", item.starring);
                Console.WriteLine("Rating : {0}", item.censor_rating);
                Console.WriteLine("Durasi : {0}", item.duration);
                Console.WriteLine("Bahasa : {0}", item.language);
                Console.WriteLine("Trailer : {0}\n", item.trailer_link);
                Console.WriteLine("Sinopsis : {0}\n", item.synopsis);
                Console.WriteLine("----------------------------------------------------------\n");
            }
        }
    }
}
