using System;
using System.Collections.Generic;
using System.Text;

namespace MASGlobalTesting.DTO.Entities
{
    public abstract class EmployeeEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        //Factory Methods Implements
        protected EmployeeEntities(decimal salary)
        {
            GetSalary(salary);
        }
        public abstract void GetSalary(decimal salary);
        public decimal Salary { get; set; }
    }
}
