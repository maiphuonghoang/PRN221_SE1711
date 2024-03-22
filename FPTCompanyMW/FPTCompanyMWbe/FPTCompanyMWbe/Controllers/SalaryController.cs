using FPTCompanyMWbe.Services;
using FPTCompanyMWbe.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace FPTCompanyMWbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : Controller
    {
        private readonly ISalaryService salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            this.salaryService = salaryService;
        }
        [HttpGet("month")]
        public async Task<IActionResult> GetSalaryByMonth(DateTime date, string employeeId = "HE151095")
        {
            var data = await salaryService.GetSalaryByMonth(employeeId, date);
            return Ok(data);
        }
    }
}
