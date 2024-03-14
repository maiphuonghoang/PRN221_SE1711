using FPTCompanyMWbe.Model.Response;

namespace FPTCompanyMWbe.Services
{
    public interface IWorkingTimeService
    {
        Task<List<GetWorkingTimeResponse>> GetWorkingTimeOfEmployeeAsync(string employeeId, DateTime from, DateTime to, int page, int pageSize);
    }
}
