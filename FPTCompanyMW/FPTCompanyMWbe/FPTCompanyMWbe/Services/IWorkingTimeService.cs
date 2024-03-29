﻿using FPTCompanyMWbe.Model.DTO;
using FPTCompanyMWbe.Model.Request;
using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using System.Data;

namespace FPTCompanyMWbe.Services
{
    public interface IWorkingTimeService
    {
        Task<PageResponse<GetWorkingTimeResponse>> GetWorkingTimeOfEmployeeAsync(string employeeId, DateTime from, DateTime to, int page, int pageSize, string sortBy, string sortOrder);
        Task<List<CheckingResponse>> GetCheckingWeeklyOfEmployeeAsync(string employeeId, DateTime date);
        Task SaveDoingCheckingAsync(CheckingRequest request);
        DataTable GetWorkingTimeExportData(string employeeId);
        Task<Dictionary<string, List<CheckingResponse>>> GetCheckingWeeklyOfListEmployeeAsync(DateTime date, String groupCode);
    }
}
