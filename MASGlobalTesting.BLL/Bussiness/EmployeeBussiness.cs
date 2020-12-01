using MASGlobalTesting.DAL.Models;
using MASGlobalTesting.DAL.RepositoriesInterfaces;
using MASGlobalTesting.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MASGlobalTesting.BLL.Bussiness
{
    public class EmployeeBussiness : IEmployeeBussiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeBussiness(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// Returns Employee by id with Annual Salary calculated
        /// </summary>
        /// <returns></returns>
        public async Task<Employee> GetById(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetById(id);
                if (employee != null)
                {
                    return GetEmployee(employee);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Returns All Employees with Annual Salary calculated
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employee>> GetAll()
        {
            try
            {
                var employees = await _employeeRepository.GetAll();
                List<Employee> lstEmployee = new List<Employee>();
                //Calculate salary to each employee
                foreach (var employee in employees)
                {
                    lstEmployee.Add(GetEmployee(employee));
                }
                return lstEmployee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Returns Employe with Annual Salary Calculated by ContractTypeName
        /// </summary>
        /// <param name="objEmployee"></param>
        /// <returns></returns>
        public static Employee GetEmployee(Employee objEmployee)
        {
            switch (objEmployee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    HourlySalaryEmployee hourlySalaryEmployee = new HourlySalaryEmployee(objEmployee.HourlySalary);
                    objEmployee.AnnualSalary = hourlySalaryEmployee.Salary;
                    break;
                case "MonthlySalaryEmployee":
                    MonthlySalaryEmployee monthlySalaryEmployee = new MonthlySalaryEmployee(objEmployee.MonthlySalary);
                    objEmployee.AnnualSalary = monthlySalaryEmployee.Salary;
                    break;
            }
            return objEmployee;
        }
    }
}
