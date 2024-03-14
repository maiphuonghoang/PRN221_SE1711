using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class JobRank
    {
        public JobRank()
        {
            Employees = new HashSet<Employee>();
        }

        public int JobRankId { get; set; }
        public string? JobCode { get; set; }
        public string JobRank1 { get; set; } = null!;
        public string? PackageCode { get; set; }

        public virtual Job? JobCodeNavigation { get; set; }
        public virtual Package? PackageCodeNavigation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
