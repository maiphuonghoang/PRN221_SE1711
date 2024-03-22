using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;

namespace FPTCompanyMWbe.Services
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeInfoResponse>> GetEmployeeInfo(string groupCode);
    }
}
