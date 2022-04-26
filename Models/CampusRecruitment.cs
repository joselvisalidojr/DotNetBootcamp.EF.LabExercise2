using System;
using System.Collections.Generic;

#nullable disable

namespace RecruitmentEmployee.Models
{
    public partial class CampusRecruitment
    {
        public CampusRecruitment()
        {
            ExternalCandidates = new HashSet<ExternalCandidate>();
        }

        public string CCampusRecruitmentCode { get; set; }
        public string CCollegeCode { get; set; }
        public DateTime? DRecruitmentStartDate { get; set; }
        public DateTime? DRecruitmentEndDate { get; set; }

        public virtual College CCollegeCodeNavigation { get; set; }
        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
    }
}
