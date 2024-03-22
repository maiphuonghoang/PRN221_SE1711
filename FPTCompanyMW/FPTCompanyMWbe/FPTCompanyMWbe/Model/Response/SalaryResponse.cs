namespace FPTCompanyMWbe.Model.Response
{
    public class SalaryResponse
    {
        public double WorkedDays { get; set; } = 0;
        public int LateDays { get; set; } = 0;
        public int EarlyDays { get; set; } = 0;
        public double StandardDays { get; set; } = 0;
        public decimal? PackageSalary { get; set; }

    }
}
