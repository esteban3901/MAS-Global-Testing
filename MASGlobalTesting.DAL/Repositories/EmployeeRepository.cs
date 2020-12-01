using MASGlobalTesting.DAL.Models;
using MASGlobalTesting.DAL.RepositoriesInterfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobalTesting.DAL.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        public EmployeeRepository(IConfiguration iconfiguration)
        {
            this.configuration = iconfiguration;
        }
        /// <summary>
        /// Returns All Employees
        /// </summary>
        /// <returns></returns>
        public Task<List<Employee>> GetAll()
        {
            return GetAllFromAPI();
        }
        /// <summary>
        /// Returns Employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> GetById(int id)
        {
            var employees = await GetAllFromAPI();
            return  employees.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// Consume WebService Employee exposed by MAS
        /// </summary>
        /// <returns></returns>
        private async Task<List<Employee>> GetAllFromAPI()
        {
            string url = configuration.GetSection("APIEmployee").GetSection("Url").Value;
            List<Employee> employees = new List<Employee>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(url+"Employees"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        employees = JsonConvert.DeserializeObject<List<Employee>>(result);
                    }
                }
            }
            return employees;
        }
    }
}
