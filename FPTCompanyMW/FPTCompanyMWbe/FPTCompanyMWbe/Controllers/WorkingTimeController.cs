﻿using ClosedXML.Excel;
using FPTCompanyMWbe.Model.Request;
using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Services;
using FPTCompanyMWbe.Utils;
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

        [HttpGet]
        public async Task<IActionResult> GetWorkingTimeOfEmployee(
            DateTime from, DateTime to,
            string employeeId = "HE151095",
            string sortBy = "dateWorking", string sortOrder = "desc",
            int page = 1, int pageSize = 5)
        {
            var data = await workingTimeService.GetWorkingTimeOfEmployeeAsync(employeeId, from, to, page, pageSize, sortBy, sortOrder);
            return Ok(data);
        }

        [HttpGet("timetable")]
        public async Task<IActionResult> GetCheckingWeeklyOfEmployee(string employeeId, DateTime date)
        {
            var data = await workingTimeService.GetCheckingWeeklyOfEmployeeAsync(employeeId, date);
            return Ok(data);
        }

        [HttpGet("sameWeekDays")]
        public IActionResult GetDaysOfWeek(DateTime date)
        {
            var daysOfWeek = DateHelper.GetDaysInSameWeekOfMonth(date);
            return Ok(daysOfWeek);
        }

        [HttpPost("checking")]
        public async Task<IActionResult> SaveDoingChecking(CheckingRequest request)
        {
            await workingTimeService.SaveDoingCheckingAsync(request);
            return Ok();
        }
        [HttpGet("ExportExcel")]
        public ActionResult ExportExcel(string employeeId)
        {
            var data = workingTimeService.GetWorkingTimeExportData(employeeId);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(data, "Working Time Report");
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sample.xlsx");
                }
            }
        }


        [HttpGet("group")]
        public async Task<ActionResult> GroupWorkingTine(DateTime date, string groupCode = "GHC")
        {
            var data = await workingTimeService.GetCheckingWeeklyOfListEmployeeAsync(date, groupCode);
            return Ok(data);
        }
    }
}
