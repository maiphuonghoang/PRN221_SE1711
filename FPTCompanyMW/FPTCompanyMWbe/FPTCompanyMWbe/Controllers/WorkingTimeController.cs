using FPTCompanyMWbe.Services;
using Microsoft.AspNetCore.Mvc;

namespace FPTCompanyMWbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingTimeController : ControllerBase
    {
        private readonly IWorkingTimeService workingTimeService;
        public WorkingTimeController(IWorkingTimeService workingTimeService)
        {
            this.workingTimeService = workingTimeService;
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetPlayerDetail(
            string employeeId, 
            DateTime from, DateTime to, 
            //string sortBy, 
            int page = 1, int pageSize = 5)
        {
            var data = await workingTimeService.GetWorkingTimeOfEmployeeAsync(employeeId, from, to, page, pageSize);
            return Ok(data);
        }
    }
}
