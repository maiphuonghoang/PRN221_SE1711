using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Repository
{
    public class WorkingTimeRepository
    {
        private readonly PRN221_FPTCompanyMWContext _context;
        private readonly EmployeeRepository _employeeRepository;
        public WorkingTimeRepository(PRN221_FPTCompanyMWContext context, EmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }
        public List<Working> GetWorkingTimeByEmployeeIdAndDate(string employeeId, DateTime from, DateTime to)
        {
            var employee = _employeeRepository.GetEmployeeWithStandardTime(employeeId);
            return employee.Workings.Where(w=> w.DateWorking >= from && w.DateWorking <= to).ToList();
        }
        public List<Working> GetWorkingTimeByEmployeeId(string employeeId)
        {
            var employee = _employeeRepository.GetEmployeeWithStandardTime(employeeId);
            return employee.Workings.ToList();
        }
        public List<Working> GetStandardWorkingTimeByEmployeeIdAndDate(string employeeId, DateTime from, DateTime to)
        {
            var employee = _employeeRepository.GetEmployeeWithStandardTime(employeeId);
            return employee.Workings
                .Where(w => w.DateWorking >= from && w.DateWorking <= to &&
                            w.DateWorking.HasValue && 
                            w.DateWorking.Value.DayOfWeek != DayOfWeek.Saturday &&
                            w.DateWorking.Value.DayOfWeek != DayOfWeek.Sunday)
                .ToList();
        }
    }
}
