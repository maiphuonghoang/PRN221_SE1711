using System;
using System.Collections.Generic;

namespace WPFMedicineSE1711.Models
{
    public partial class Medicine
    {
        public string MedicineId { get; set; } = null!;
        public int GroupId { get; set; }
        public int SupplierId { get; set; }
        public string MedicineName { get; set; } = null!;
        public decimal? Price { get; set; }
        public double? Amount { get; set; }
        public DateTime? ExpiriDate { get; set; }
        public string? Preserve { get; set; }
        public string? UserManual { get; set; }

        public virtual GroupMedicine Group { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
    }
}
