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
    internal class MonthlySalaryRepository
    {
        public RecruitmentContext Context { get; set; }

        public MonthlySalaryRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public List<MonthlySalary> GetMonthlySalaryByEmployeeCode(string code)
        {
            var monthlySalary = this.Context.MonthlySalaries.Where(p => p.CEmployeeCode == code).ToList();
            if (monthlySalary != null)
            {
                return monthlySalary;
            }
            throw new Exception($"Monthly Salary with code {code} doesn't exist");
        }
    }
}
