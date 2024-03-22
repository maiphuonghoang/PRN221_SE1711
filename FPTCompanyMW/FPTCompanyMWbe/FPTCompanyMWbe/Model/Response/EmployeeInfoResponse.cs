using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Model.Response
{
    [Keyless]

    public class EmployeeInfoResponse
    {
        public string EmployeeId { get; set; } = null!;
        public string? EmployeeName { get; set; }
        public string GroupCode { get; set; } = null!;
        public string? JobCode { get; set; }
        public int? StandardTimeId { get; set; }
        public decimal? PackageSalary { get; set; }
    }
}
