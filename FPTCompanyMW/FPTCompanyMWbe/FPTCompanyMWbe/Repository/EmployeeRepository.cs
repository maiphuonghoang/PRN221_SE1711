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
        public async Task<Employee> GetEmployeeId(string id)
        {
            return await _context.Employees.FindAsync(id);
        }
    }
}
