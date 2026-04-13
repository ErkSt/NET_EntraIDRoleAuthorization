using ApiTestEntraID.Application.DTOs;

namespace ApiTestEntraID.Application.Interfaces;

public interface IReportService
{
    ReportStatsDto GetByDepartment(int departmentId);
}