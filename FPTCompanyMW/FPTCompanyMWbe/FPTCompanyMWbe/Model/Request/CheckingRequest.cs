namespace FPTCompanyMWbe.Model.Request
{
    public class CheckingRequest
    {
        public string EmployeeId { get; set; }
        public DateTime? DateWorking { get; set; } = DateTime.Now;
    }
}
