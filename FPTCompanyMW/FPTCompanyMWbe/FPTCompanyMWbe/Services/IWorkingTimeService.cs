using FPTCompanyMWbe.Model.DTO;
using FPTCompanyMWbe.Model.Request;
using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;

namespace FPTCompanyMWbe.Services
{
    public interface IWorkingTimeService
    {
        Task<PageResponse<GetWorkingTimeResponse>> GetWorkingTimeOfEmployeeAsync(string employeeId, DateTime from, DateTime to, int page, int pageSize, string sortBy, string sortOrder);
        Task<List<CheckingResponse>> GetCheckingWeeklyOfEmployeeAsync(string employeeId, DateTime date);
        Task SaveDoingCheckingAsync(CheckingRequest request);

    }
}
