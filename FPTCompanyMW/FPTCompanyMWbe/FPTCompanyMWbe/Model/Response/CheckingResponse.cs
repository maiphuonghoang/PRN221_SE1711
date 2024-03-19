namespace FPTCompanyMWbe.Model.Response
{
    public class CheckingResponse
    {
        public DateTime DateWorking { get; set; }
        public TimeSpan? FirstEntryTime { get; set; }
        public TimeSpan? LastExistTime { get; set; }
        public bool? IsCheckInOnTime { get; set; }
        public bool? IsCheckOutOnTime { get; set; }
    }
}
