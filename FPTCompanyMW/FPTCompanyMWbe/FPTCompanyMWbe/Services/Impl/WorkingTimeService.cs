using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Services.Impl
{
    public class WorkingTimeService : IWorkingTimeService
    {
        private readonly PRN221_FPTCompanyMWContext _context;
        public WorkingTimeService(PRN221_FPTCompanyMWContext context)
        {
            _context = context ?? new PRN221_FPTCompanyMWContext();
        }

        public async Task<List<GetWorkingTimeResponse>> GetWorkingTimeOfEmployeeAsync(
            string employeeId, DateTime from, DateTime to, 
            int page, int pageSize)
        {
            if (from == DateTime.MinValue || to == DateTime.MinValue)
            {
                from = DateTime.MinValue;
                to = DateTime.Now;
            }

            Employee employee = _context.Employees.Include(e => e.Workings)
                .FirstOrDefault(e => e.EmployeeId.Equals(employeeId));
            List<GetWorkingTimeResponse> getWorkingTimeResponses = new List<GetWorkingTimeResponse>();
            foreach(var item in employee.Workings)
            {
                getWorkingTimeResponses.Add(new GetWorkingTimeResponse
                {
                    DateWorking = (DateTime)item.DateWorking,
                    FirstEntryTime = (TimeSpan)item.FirstEntryTime,
                    LastExistTime = (TimeSpan)item.LastExistTime,
                    workedHoursInOfficeTime = (float)(item.LastExistTime - item.FirstEntryTime).GetValueOrDefault().TotalHours
                }); 
            }
            var result = getWorkingTimeResponses
                .OrderBy(w=>w.DateWorking)
                .Skip((page-1)*pageSize).Take(pageSize).ToList();
            return result;
        }
        public float calculateWorkedTimeInTimeFrame(
            TimeSpan checkIn, TimeSpan checkOut, 
            TimeSpan startMorning, TimeSpan endMorning,
            TimeSpan startAfternoon, TimeSpan endAfternoon
            )
        {
            return 0;
        }
    }
}
