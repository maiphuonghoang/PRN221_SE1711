namespace FPTCompanyMWbe.Utils
{
    public class DateHelper
    {
        public static List<DateTime> GetDaysInSameWeekOfMonth(DateTime date)
        {
            DateTime localDate = date.Date;
            DayOfWeek dow = localDate.DayOfWeek;
            DateTime startOfWeek = localDate.AddDays(-(int)dow + 1);
            DateTime endOfWeek = startOfWeek.AddDays(6);
            List<DateTime> daysInSameWeek = new List<DateTime>();
            for (DateTime d = startOfWeek; d <= endOfWeek; d = d.AddDays(1))
            {
                daysInSameWeek.Add(d);
            }
            return daysInSameWeek;
        }
    }
}
