using FPTCompanyMWbe.Model.Response;
using FPTCompanyMWbe.Models;
using Microsoft.EntityFrameworkCore;
namespace FPTCompanyMWbe.Repository
{
    public class EmployeeRepository
    {
        private readonly PRN221_FPTCompanyMWContext _context;
        public EmployeeRepository(PRN221_FPTCompanyMWContext context)
        {
            _context = context;
        }
        public Employee GetEmployeeWithStandardTime(string employeeId)
        {
            return _context.Employees
                .Include(e => e.Workings)
                .Include(e => e.Participates)
                .ThenInclude(p => p.StandardTime)
                .FirstOrDefault(e => e.EmployeeId.Equals(employeeId));
        }
        public List<EmployeeInfoResponse> GetEmployeeByGroup(string groupCode)
        {
            string sqlQuery = @"
                SELECT e.employeeId, e.employeeName, g.groupCode, 
                       j.jobCode, j.jobName, 
                       jr.jobRank, jr.packageCode, 
                       pk.packageSalary, 
                       st.standardTimeId, st.morningStartTime, 
                       st.afternoonEndTime
                FROM [Group] g 
                JOIN Participate p ON g.groupCode = p.groupCode 
                JOIN Employee e ON e.employeeId = p.employeeId 
                JOIN Salary s ON s.employeeId = e.employeeId
                JOIN JobRank jr ON jr.jobRankId = s.jobRankId
                JOIN Job j ON j.jobCode = jr.jobCode
                JOIN Package pk ON pk.packageCode = jr.packageCode
                JOIN StandardTime st ON st.standardTimeId = p.standardTimeId 
                WHERE g.groupCode = {0}";

            return _context.EmployeeInfoResponse.FromSqlRaw(sqlQuery, groupCode).ToList();

        }
        public EmployeeInfoResponse GetEmployeeWithSalary(string employeeId)
        {
            string sqlQuery = @"
                SELECT e.employeeId, e.employeeName, g.groupCode, 
                       j.jobCode, j.jobName, 
                       jr.jobRank, jr.packageCode, 
                        st.standardTimeId,
                       pk.packageSalary
                FROM [Group] g 
                JOIN Participate p ON g.groupCode = p.groupCode 
                JOIN Employee e ON e.employeeId = p.employeeId 
                JOIN Salary s ON s.employeeId = e.employeeId
                JOIN JobRank jr ON jr.jobRankId = s.jobRankId
                JOIN Job j ON j.jobCode = jr.jobCode
                JOIN Package pk ON pk.packageCode = jr.packageCode
                JOIN StandardTime st ON st.standardTimeId = p.standardTimeId 
                WHERE e.employeeId = {0}
                ";

            return _context.EmployeeInfoResponse.FromSqlRaw(sqlQuery, employeeId)
                                         .FirstOrDefault();

        }
    }
}