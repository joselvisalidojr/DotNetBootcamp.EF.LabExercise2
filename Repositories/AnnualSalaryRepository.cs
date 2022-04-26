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
    internal class AnnualSalaryRepository
    {
        public RecruitmentContext Context { get; set; }

        public AnnualSalaryRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public List<AnnualSalary> GetAnnualSalaryByEmployeeCode(string code)
        {
            var annualSalary = this.Context.AnnualSalaries.Where(p => p.CEmployeeCode == code).ToList();
            if (annualSalary != null)
            {
                return annualSalary;
            }
            throw new Exception($"Annual Salary with code {code} doesn't exist");
        }
    }
}
