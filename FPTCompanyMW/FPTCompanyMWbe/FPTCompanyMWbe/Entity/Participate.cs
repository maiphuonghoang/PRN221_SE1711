using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Participate
    {
        public string GroupCode { get; set; } = null!;
        public string EmployeeId { get; set; } = null!;
        public int StandardTimeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Group GroupCodeNavigation { get; set; } = null!;
        public virtual StandardTime StandardTime { get; set; } = null!;
    }
}
