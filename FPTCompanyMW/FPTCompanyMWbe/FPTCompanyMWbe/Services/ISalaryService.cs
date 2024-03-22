using FPTCompanyMWbe.Model.Response;

namespace FPTCompanyMWbe.Services
{
    public interface ISalaryService
    {
        Task<SalaryResponse> GetSalaryByMonth(string employeeId, DateTime date);
    }
}
