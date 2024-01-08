using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorInfo.Models
{
    public partial class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Description { get; set; }
        public bool? Male { get; set; }
        public string? GenderString { get; set; }
        public string? Nationality { get; set; }
    }
}
