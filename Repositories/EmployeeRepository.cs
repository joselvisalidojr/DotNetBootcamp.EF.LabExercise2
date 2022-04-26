using RecruitmentEmployee.Data;
using RecruitmentEmployee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentEmployee.Repositories
{
    internal class EmployeeRepository
    {
        public RecruitmentContext Context { get; set; }

        public EmployeeRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public Employee FindByCode(string code)
        {
            var employee = this.Context.Employees.Where(p => p.CEmployeeCode == code).FirstOrDefault();
            if (employee != null)
            {
                return employee;
            }
            throw new Exception($"Employee with code '{code}' doesn't exist");
        }
    }
}
