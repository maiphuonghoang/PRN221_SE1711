using FPTCompanyMWbe.Entity;
using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Repository;
using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Services.Impl
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;
        public MyBackgroundService(ILogger<MyBackgroundService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Background worker started at: {time}", DateTime.Now);
                await InsertDataIntoDatabase();
                await Task.Delay(TimeSpan.FromDays(30), stoppingToken);

            }
        }
        private async Task InsertDataIntoDatabase()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopeContext = scope.ServiceProvider.GetRequiredService<PRN221_FPTCompanyMWContext>();
                var _employeeRepository = scope.ServiceProvider.GetRequiredService<EmployeeRepository>();
                var _workingRepository = scope.ServiceProvider.GetRequiredService<WorkingTimeRepository>();
                List<Employee> employees = scopeContext.Employees.ToList();
                List<SalaryResponse> salaries = new List<SalaryResponse>();

                var date = getDayOfPreviousMonth();

                foreach (Employee employee in employees)
                {
                    //SalaryResponse salary = await GetSalaryByMonth(employee.EmployeeId, date);


                    var salary = new SalaryResponse();
                    salary.EmployeeId = employee.EmployeeId;

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
                    string sqlQuery = @"
                             SELECT e.employeeId, e.employeeName, g.groupCode, 
                                   j.jobCode, j.jobName, 
                                   jr.jobRank, jr.packageCode, 
                                    st.standardTimeId,
                                   pk.packageSalary
                            FROM [Group] g 
                            JOIN Participate p ON g.groupCode = p.groupCode 
                            JOIN Employee e ON e.employeeId = p.employeeId 
                            JOIN Salary s ON s.employeeId = e.employeeId
                            JOIN JobRank jr ON jr.jobRankId = s.jobRankId
                            JOIN Job j ON j.jobCode = jr.jobCode
                            JOIN Package pk ON pk.packageCode = jr.packageCode
                            JOIN StandardTime st ON st.standardTimeId = p.standardTimeId 
                            WHERE e.employeeId = {0}
                            ";

                    EmployeeInfoResponse raw = scopeContext.EmployeeInfoResponse.FromSqlRaw(sqlQuery, employee.EmployeeId)
                                                 .SingleOrDefault();

                    if (raw != null)
                    {
                        salary.PackageSalary = raw.PackageSalary;
                        Employee e = _employeeRepository.GetEmployeeWithStandardTime(employee.EmployeeId);
                        var workings = _workingRepository.GetStandardWorkingTimeByEmployeeIdAndDate(employee.EmployeeId, firstDayOfMonth, lastDayOfMonth);
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
                        salaries.Add(salary);
                    }

                }
                _logger.LogInformation("Background worker ended at: {time}", DateTimeOffset.Now);
                _logger.LogInformation(salaries.Count + "");
                for (int i = 0; i < salaries.Count; i++)
                {
                    var salary = salaries[i];
                    double salaryMoney = salaries[i].WorkedDays != 0?((double)salaries[i].PackageSalary * salaries[i].WorkedDays  / salaries[i].StandardDays) - ((salaries[i].EarlyDays + salaries[i].LateDays) * 20000) : 0;
                    _logger.LogInformation($"Salary at index {i}: {salary.EmployeeId} {salary.PackageSalary} {salaries[i].StandardDays} {salaries[i].WorkedDays} {salaries[i].EarlyDays} {salaries[i].LateDays} {salaryMoney}"); 
                }
                List<SalaryHistory> insertData = new List<SalaryHistory>();
                foreach(var s in salaries)
                {
                    insertData.Add(new SalaryHistory
                    {
                        Id = 0,
                        EmployeeId = s.EmployeeId,
                        WorkedDays = s.WorkedDays,
                        StandardDays = (int) s.StandardDays,
                        EarlyDays = s.EarlyDays,
                        LateDays = s.LateDays,
                        CurrentMonth = 2, 
                        SalaryMoney = s.WorkedDays != 0
                            ? ((double)s.PackageSalary * s.WorkedDays / s.StandardDays) - ((s.EarlyDays + s.LateDays) * 20000)
                            : 0
                    });

                }
                await scopeContext.SalaryHistories.AddRangeAsync(insertData);
                await scopeContext.SaveChangesAsync();

            }
        }

        public DateTime getDayOfPreviousMonth()
        {
            DateTime currentDate = DateTime.Now;

            DateTime previousMonth = currentDate.AddMonths(-1);

            int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);

            Random random = new Random();
            int randomDay = random.Next(1, daysInPreviousMonth + 1);

            DateTime randomDateInPreviousMonth = new DateTime(previousMonth.Year, previousMonth.Month, randomDay);
            return randomDateInPreviousMonth;
        }
    }
}
