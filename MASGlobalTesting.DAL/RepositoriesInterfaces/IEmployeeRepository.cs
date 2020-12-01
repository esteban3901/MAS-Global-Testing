using MASGlobalTesting.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobalTesting.DAL.RepositoriesInterfaces
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Returns all employees from WebService
        /// </summary>
        /// <returns></returns>
        Task<List<Employee>> GetAll();

        /// <summary>
        /// Returns employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Employee> GetById(int id);
    }
}
