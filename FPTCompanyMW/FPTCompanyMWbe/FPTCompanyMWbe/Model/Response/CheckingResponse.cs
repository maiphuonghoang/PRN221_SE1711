namespace FPTCompanyMWbe.Model.Response
{
    public class CheckingResponse
    {
        public DateTime DateWorking { get; set; }
        public TimeSpan? FirstEntryTime { get; set; } = null;
        public TimeSpan? LastExistTime { get; set; } = null;
        public bool? IsCheckInOnTime { get; set; } = null;
        public bool? IsCheckOutOnTime { get; set; } = null;
        public bool IsOffDay { get; set; } = false;
    }
}
