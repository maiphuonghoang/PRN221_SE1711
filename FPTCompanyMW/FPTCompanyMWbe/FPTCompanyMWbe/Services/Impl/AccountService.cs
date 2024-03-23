using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Services.Impl
{
    public class AccountService : IAccountService
    {
        private readonly PRN221_FPTCompanyMWContext _context;

        public AccountService(PRN221_FPTCompanyMWContext context)
        {
            _context = context;
        }

        public AccountResponse Login(string email, string password)
        {
                var user = _context.Accounts.Include("Roles").Include(a=>a.Employee)
                .Where(u => u.Username.Equals(email) && u.Password.Equals(password))
                .FirstOrDefault();
                if (user != null)
                {
                    return new AccountResponse
                    {
                        EmployeeId = user.Employee.EmployeeId,
                        RoleId = user.Roles.FirstOrDefault().RoleId,
                        RoleName = user.Roles.FirstOrDefault()?.RoleName,
                    };
                }
            return null;
        }
    }
}
