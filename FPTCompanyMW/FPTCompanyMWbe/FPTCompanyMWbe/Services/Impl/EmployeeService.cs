using FPTCompanyMWbe.Entity;
using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Repository;

namespace FPTCompanyMWbe.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PRN221_FPTCompanyMWContext _context;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(PRN221_FPTCompanyMWContext context, EmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        public Task<List<EmployeeInfoResponse>> GetEmployeeInfo(string groupCode)
        {
            return Task.FromResult(_employeeRepository.GetEmployeeByGroup(groupCode));
        }

    }
}
