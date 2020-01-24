using System;
using System.Threading.Tasks;
using EmpFetcher;

namespace employee
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://mul14.github.io/data/employees.json";

           EMPF empf = new EMPF(url);
           await empf.Fetch();

            separator("employee with salary more than 15.000.000");
            foreach (var e in empf.GetSalaryMoreThan(15000000))
               Console.WriteLine(e);

            separator("employee who adress in jakarta");
            foreach (var e in empf.GetEmpAddrByCity("jakarta"))
               Console.WriteLine(e);

            separator("employee which birthday on march");
            foreach (var e in empf.GetEmpBirthday("Maret"))
               Console.WriteLine(e);

            separator("employee which RnD");
            foreach (var e in empf.GetEmpByDep("Research and development"))
               Console.WriteLine(e);
               
            separator("employee absence in oktober");
            foreach (var e in empf.GetEmpAbsByMonth("Oktober"))
                Console.WriteLine("{0}  :  {1}", e.Key, e.Value);
        }

        static void separator( string info)
        {
            Console.WriteLine();
            Console.WriteLine("==========================================");
            Console.WriteLine(info);
        }
    }
}
