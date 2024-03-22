using FPTCompanyMWbe.Repository;
using FPTCompanyMWbe.Services;
using FPTCompanyMWbe.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace FPTCompanyMWbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet("group")]
        public async Task<IActionResult> GetEmployeeInfo(string groupCode)
        {
            var data = await _employeeService.GetEmployeeInfo(groupCode);
            return Ok(data);
        }
    }
}
