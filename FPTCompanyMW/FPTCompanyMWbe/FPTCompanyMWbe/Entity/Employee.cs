using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Groups = new HashSet<Group>();
            Participates = new HashSet<Participate>();
            Workings = new HashSet<Working>();
            JobRanks = new HashSet<JobRank>();
        }

        public string EmployeeId { get; set; } = null!;
        public string? EmployeeName { get; set; }
        public bool? Gender { get; set; }
        public string? EmployeeImage { get; set; }
        public string AccountId { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Participate> Participates { get; set; }
        public virtual ICollection<Working> Workings { get; set; }

        public virtual ICollection<JobRank> JobRanks { get; set; }
    }
}
