using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTCompanyMWbe.Repository
{
    public class WorkingTimeRepository
    {
        private readonly PRN221_FPTCompanyMWContext _context;
        public WorkingTimeRepository(PRN221_FPTCompanyMWContext context)
        {
            _context = context;
        }

    }
}
