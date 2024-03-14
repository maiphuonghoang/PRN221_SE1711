using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class StandardTime
    {
        public StandardTime()
        {
            Participates = new HashSet<Participate>();
        }

        public int StandardTimeId { get; set; }
        public TimeSpan? MorningStartTime { get; set; }
        public TimeSpan? MorningEndTime { get; set; }
        public TimeSpan? AfternoonStartTime { get; set; }
        public TimeSpan? AfternoonEndTime { get; set; }

        public virtual ICollection<Participate> Participates { get; set; }
    }
}
