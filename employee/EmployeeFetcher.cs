using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Globalization;
using EmployeeSys;

namespace EmpFetcher
{
    public class EMPF
    {
        private string _url;
        private string _rawJson;
        private List<Employee> employee;

        public EMPF(string url)
        {
            _url = url;
        }

        public async Task<int> Fetch()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, _url);
            HttpResponseMessage response = await client.SendAsync(req);
            _rawJson = await response.Content.ReadAsStringAsync();
            employee = JsonConvert.DeserializeObject<List<Employee>>(_rawJson);
            return (int) response.StatusCode;
        }

        public List<string> GetSalaryMoreThan(double sal)
        {
            var ret = from emp in employee where(emp.salary > sal) 
                        select $"{emp.first_name} {emp.last_name}";
            return ret.ToList();
        }

        public List<string> GetEmpAddrByCity(string city)
        {
            var ret = from emp in employee from add in emp.addresses 
                        where(add.city.IndexOf(city, 0, StringComparison.CurrentCultureIgnoreCase) != -1 )
                        select $"{emp.first_name} {emp.last_name}";
            return ret.Distinct().ToList();
        }

        public List<string> GetEmpBirthday(string month)
        {
            var ci = new CultureInfo("id-ID");
            int dt = DateTime.ParseExact(month, "MMMM", ci).Month;

            var ret = from emp in employee where(emp.birthday.Month == dt)
                        select $"{emp.first_name} {emp.last_name}";
            return ret.ToList();
        }

        public List<string> GetEmpByDep(string dep)
        {
            var ret = from emp in employee where(emp.department.name == dep)
                        select $"{emp.first_name} {emp.last_name}";
            return ret.ToList();
        }

        public Dictionary<string, int> GetEmpAbsByMonth(string month)
        {
            var ci = new CultureInfo("id-ID");
            int dt = DateTime.ParseExact(month, "MMMM", ci).Month;

            var ret = from emp in employee from pl in emp.presence_list
                        where(pl.Month == dt)
                        select $"{emp.first_name} {emp.last_name}";

            Dictionary<string, int> ret1 = ret.GroupBy(n => n).ToDictionary(
                abs => abs.Key,
                abs => abs.Count()
            );

            return ret1;
        }

    }
}