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
    internal class EmployeeSkillRepository
    {
        public RecruitmentContext Context { get; set; }

        public EmployeeSkillRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public IEnumerable<dynamic> GetEmployeeSkillsByEmployeeCode(string code)
        {
            var skills = this.Context.EmployeeSkills
                .Join(Context.Skills, employee => employee.CSkillCode, skill => skill.CSkillCode,(employee, skill) => new
                {
                    CEmployeeCode = employee.CEmployeeCode,
                    CSkillCode = skill.VSkill
                }
                )
                .Where(p => p.CEmployeeCode == code)
                .ToList();

            if (skills != null)
            {
                return skills;
            }
            throw new Exception($"Employee Skill with code {code} doesn't exist");
        }
    }
}
