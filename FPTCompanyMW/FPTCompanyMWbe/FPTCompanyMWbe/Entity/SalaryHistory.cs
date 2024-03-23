using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Entity
{
    public partial class SalaryHistory
    {
        public int Id { get; set; }
        public string? EmployeeId { get; set; }
        public double? WorkedDays { get; set; }
        public int? LateDays { get; set; }
        public int? EarlyDays { get; set; }
        public int? StandardDays { get; set; }
        public double? SalaryMoney { get; set; }
        public int? CurrentMonth { get; set; }
    }
}
