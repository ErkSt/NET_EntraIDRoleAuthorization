using ApiTestEntraID.Application.DTOs;
using ApiTestEntraID.Application.Interfaces;

namespace ApiTestEntraID.Infrastructure.Services;

public sealed class MockReportService : IReportService
{
    private readonly ITaskRepository _taskRepository;

    public MockReportService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public ReportStatsDto GetByDepartment(int departmentId)
    {
        var tasks = _taskRepository.GetByDepartment(departmentId);
        var total = tasks.Count;

        return new ReportStatsDto
        {
            TotalTasks = total,
            OpenTasks = total == 0 ? 0 : (int)Math.Ceiling(total * 0.7),
            ClosedTasks = total == 0 ? 0 : (int)Math.Floor(total * 0.3)
        };
    }
}