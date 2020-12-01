using System;
using System.Collections.Generic;
using System.Text;

namespace MASGlobalTesting.DTO.Entities
{
    public class MonthlySalaryEmployee:EmployeeEntities
    {
        public MonthlySalaryEmployee(decimal salary) : base(salary)
        {
        }
        /// <summary>
        /// Calculate Salary by TypeContract Monthly
        /// </summary>
        /// <param name="salary"></param>
        public override void GetSalary(decimal salary)
        {
            Salary = salary * 12;
        }
    }
}
