using MASGlobalTesting.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobalTesting.BLL.Bussiness
{
    public interface IEmployeeBussiness
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
    }
}
