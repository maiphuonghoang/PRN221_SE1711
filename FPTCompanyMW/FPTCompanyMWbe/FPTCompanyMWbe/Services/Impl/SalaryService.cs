using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Repository;

namespace FPTCompanyMWbe.Services.Impl
{
    public class SalaryService : ISalaryService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly WorkingTimeRepository _workingTimeRepository;
        public SalaryService( EmployeeRepository employeeRepository, WorkingTimeRepository workingTimeRepository)
        {
            _employeeRepository = employeeRepository;
            _workingTimeRepository = workingTimeRepository;
        }

        public Task<SalaryResponse> GetSalaryByMonth(string employeeId, DateTime date)
        {
            var salary = new SalaryResponse();

            date = new DateTime(2024, 2, 15);
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            // Get the last day of the month by moving to the next month and subtracting one day
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            int notWeekendCount = 0;
            for (DateTime currentDate = firstDayOfMonth; currentDate <= lastDayOfMonth; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    notWeekendCount++;
                }
            }
            salary.StandardDays = notWeekendCount;
            salary.PackageSalary = _employeeRepository.GetEmployeeWithSalary(employeeId).PackageSalary;

            Employee employee = _employeeRepository.GetEmployeeWithStandardTime(employeeId);
            var workings = _workingTimeRepository.GetStandardWorkingTimeByEmployeeIdAndDate(employeeId, firstDayOfMonth, lastDayOfMonth);
            var standardTime = employee.Participates.FirstOrDefault().StandardTime;
            TimeSpan startMorning = (TimeSpan)standardTime?.MorningStartTime;
            TimeSpan endMorning = (TimeSpan)standardTime?.MorningEndTime;
            TimeSpan startAfternoon = (TimeSpan)standardTime?.AfternoonStartTime;
            TimeSpan endAfternoon = (TimeSpan)standardTime?.AfternoonEndTime;
            TimeSpan workedTime;
            foreach (var working in workings)
            {
                var checkIn = working.FirstEntryTime;
                var checkOut = working.LastExistTime;

                switch (true)
                {
                    case bool _ when checkIn <= startMorning && checkOut >= endAfternoon:
                        workedTime = endMorning - startMorning + endAfternoon - startAfternoon;
                        if ((float)workedTime.TotalHours >= 6)
                            salary.WorkedDays += 1;
                        break;
                    case bool _ when startMorning < checkIn && checkIn < endMorning && checkOut >= endAfternoon:
                        workedTime = (TimeSpan)(endMorning - checkIn + endAfternoon - startAfternoon);
                        if ((float)workedTime.TotalHours >= 6)
                            salary.WorkedDays += 1;
                        salary.LateDays += 1;
                        break;
                    case bool _ when startMorning <= checkIn && checkIn < endMorning && startAfternoon < checkOut && checkOut < endAfternoon:
                        workedTime = (TimeSpan)(endMorning - startMorning + checkOut - startAfternoon);
                        if ((float)workedTime.TotalHours >= 6)
                            salary.WorkedDays += 1;
                        salary.EarlyDays += 1;
                        break;
                    case bool _ when startMorning < checkIn && checkIn < endMorning && startAfternoon < checkOut && checkOut < endMorning:
                        workedTime = (TimeSpan)(endMorning - checkIn + checkOut - startAfternoon);
                        if ((float)workedTime.TotalHours >= 6)
                            salary.WorkedDays += 1;
                        salary.LateDays += 1;
                        salary.EarlyDays += 1;
                        break;
                    case bool _ when checkIn < startMorning && checkIn < endMorning && endMorning <= checkOut && checkOut < startAfternoon:
                        workedTime = endMorning - startMorning;
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        break;
                    case bool _ when checkIn < endMorning && endMorning <= checkOut && checkOut < startAfternoon:
                        workedTime = (TimeSpan)(endMorning - checkIn);
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        salary.LateDays += 1;
                        break;
                    case bool _ when checkIn <= startMorning && checkOut < endMorning:
                        workedTime = (TimeSpan)checkOut - startMorning;
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        salary.EarlyDays += 1;
                        break;
                    case bool _ when checkIn < startMorning && checkOut < endMorning:
                        workedTime = (TimeSpan)(checkOut - checkIn);
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        salary.LateDays += 1;
                        salary.EarlyDays += 1;
                        break;
                    case bool _ when endMorning < checkIn && checkIn <= startAfternoon && checkOut >= endAfternoon:
                        workedTime = endAfternoon - startAfternoon;
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        break;
                    case bool _ when checkIn > startAfternoon && checkIn <= endAfternoon && checkOut >= endAfternoon:
                        workedTime = (TimeSpan)(endAfternoon - checkIn);
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        salary.LateDays += 1;
                        break;
                    case bool _ when endMorning < checkIn && checkIn <= startAfternoon && checkOut < endAfternoon:
                        workedTime = (TimeSpan)checkOut - startAfternoon;
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        salary.EarlyDays += 1;
                        break;
                    case bool _ when checkIn > startAfternoon && checkOut < endAfternoon:
                        workedTime = (TimeSpan)(checkOut - checkIn);
                        if ((float)workedTime.TotalHours >= 3)
                            salary.WorkedDays += 0.5;
                        salary.LateDays += 1;
                        salary.EarlyDays += 1;
                        break;
                    default:
                        workedTime = TimeSpan.Zero;
                        break;
                }
            }
            return Task.FromResult(salary);
        }
    }
}
