using FPTCompanyMWbe.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Repository
{
    public class EmployeeRepository
    {
        private readonly PRN221_FPTCompanyMWContext _context;
        public EmployeeRepository(PRN221_FPTCompanyMWContext context)
        {
            _context = context;
        }
        public Employee GetEmployeeWithStandardTime(string employeeId)
        {
            return _context.Employees
                .Include(e => e.Workings)
                .Include(e => e.Participates)
                .ThenInclude(p => p.StandardTime)
                .FirstOrDefault(e => e.EmployeeId.Equals(employeeId));
        }
    }
}
