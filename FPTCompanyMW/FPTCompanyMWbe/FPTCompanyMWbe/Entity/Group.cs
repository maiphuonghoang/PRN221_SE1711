using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Group
    {
        public Group()
        {
            Participates = new HashSet<Participate>();
        }

        public string GroupCode { get; set; } = null!;
        public string? GroupName { get; set; }
        public string? BuId { get; set; }

        public virtual Employee? Bu { get; set; }
        public virtual ICollection<Participate> Participates { get; set; }
    }
}
