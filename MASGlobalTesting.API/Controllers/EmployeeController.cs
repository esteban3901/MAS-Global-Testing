using MASGlobalTesting.API.Models;
using MASGlobalTesting.BLL.Bussiness;
using MASGlobalTesting.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASGlobalTesting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBussiness _employeeBussiness;
        public EmployeeController(IEmployeeBussiness employeeBussiness)
        {
            _employeeBussiness = employeeBussiness;
        }
        /// <summary>
        /// Returns All Employees with AnnualSalary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            APIResponseModel<IEnumerable<Employee>> response;
            IEnumerable<Employee> employees = await _employeeBussiness.GetAll();
            response = new APIResponseModel<IEnumerable<Employee>>()
            {
                Status = employees.Any(),
                Result = employees.Any() ? employees : null
            };
            return Ok(response);
        }
        /// <summary>
        /// Returns Employees by Id with AnnualSalary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            APIResponseModel<Employee> response;
            Employee employee = await _employeeBussiness.GetById(id);

            response = new APIResponseModel<Employee>()
            {
                Status = true,
                Result = employee
            };
            return Ok(response);
        }
    }
}
