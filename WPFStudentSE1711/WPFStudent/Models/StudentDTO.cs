using System;
using System.Collections.Generic;

namespace WPFStudent.Models
{
    public partial class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string? GenderString { get; set; }
        public bool? Male { get; set; }
        public bool? Female { get; set; }
        public int? Major { get; set; }
        public string? MajorName { get; set; }
        public virtual Major? MajorNavigation { get; set; }
    }
}