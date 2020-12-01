using System;
using System.Collections.Generic;
using System.Text;

namespace MASGlobalTesting.DTO.Entities
{
    public class HourlySalaryEmployee:EmployeeEntities
    {
        public HourlySalaryEmployee(decimal salary) : base(salary)
        {
        }
        /// <summary>
        /// Calculate Salary by TypeContract Hourly
        /// </summary>
        /// <param name="salary"></param>
        public override void GetSalary(decimal salary)
        {
            Salary = salary * 120 * 12;
        }
    }
}
