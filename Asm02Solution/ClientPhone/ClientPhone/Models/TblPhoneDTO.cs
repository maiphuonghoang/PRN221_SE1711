using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPhone.Models
{
    internal class TblPhoneDTO
    {
        public int Id { get; set; }
        public string? Branch { get; set; }
        public string? Name { get; set; }
        public DateTime? DateofManufacture { get; set; }
        public bool? StopManufacture { get; set; }
        public string? StopManufactureString { get; set; }
    }
}
