using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Working
    {
        public int WorkingId { get; set; }
        public string EmployeeId { get; set; } = null!;
        public DateTime? DateWorking { get; set; }
        public TimeSpan? FirstEntryTime { get; set; }
        public TimeSpan? LastExistTime { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
