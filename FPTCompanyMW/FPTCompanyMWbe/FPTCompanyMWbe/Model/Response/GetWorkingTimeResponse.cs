using System.Runtime.CompilerServices;

namespace FPTCompanyMWbe.Model.Response
{
    public class GetWorkingTimeResponse
    {
        public DateTime DateWorking { get; set; }
        public TimeSpan FirstEntryTime { get; set; }
        public TimeSpan? LastExistTime { get; set; }
        public float? workedHoursInOfficeTime { get; set; }
        public float? workedHoursInTimeFrame { get; set; }
        public bool IsOffDay { get; set; } = false;

    }
}
