using FPTCompanyMWbe.Model.Response;

namespace FPTCompanyMWbe.Services.Impl
{
    public interface IAccountService
    {
        AccountResponse Login(string email, string password);
    }
}
