using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Package
    {
        public Package()
        {
            JobRanks = new HashSet<JobRank>();
        }

        public string PackageCode { get; set; } = null!;
        public decimal PackageSalary { get; set; }

        public virtual ICollection<JobRank> JobRanks { get; set; }
    }
}
