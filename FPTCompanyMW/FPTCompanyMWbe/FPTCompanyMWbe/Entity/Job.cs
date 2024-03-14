using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Job
    {
        public Job()
        {
            JobRanks = new HashSet<JobRank>();
        }

        public string JobCode { get; set; } = null!;
        public string JobName { get; set; } = null!;

        public virtual ICollection<JobRank> JobRanks { get; set; }
    }
}
