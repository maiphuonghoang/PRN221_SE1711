using System;
using System.Collections.Generic;

namespace WPFStudent.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Credit { get; set; }
        public string? Comment { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
