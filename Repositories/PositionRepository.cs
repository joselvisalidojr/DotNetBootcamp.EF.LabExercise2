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
    internal class PositionRepository
    {
        public RecruitmentContext Context { get; set; }

        public PositionRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public Position GetPositionByCode(string code)
        {
            var position = this.Context.Positions.Where(p => p.CPositionCode == code).FirstOrDefault();
            if (position != null)
            {
                return position;
            }
            throw new Exception($"Position with code {code} doesn't exist");
        }
    }
}
