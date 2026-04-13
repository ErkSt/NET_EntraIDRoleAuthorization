using ApiTestEntraID.Application.Interfaces;
using ApiTestEntraID.Domain.Entities;

namespace ApiTestEntraID.Infrastructure.Repositories;

public sealed class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<WorkTask> _tasks =
    [
        new()
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Date = DateTime.UtcNow.Date.AddDays(-2),
            Description = "Update internal API guide",
            DepartmentId = 1,
            AssignedUserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        },
        new()
        {
            Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
            Date = DateTime.UtcNow.Date.AddDays(-1),
            Description = "Prepare onboarding checklist",
            DepartmentId = 2,
            AssignedUserId = Guid.Parse("22222222-2222-2222-2222-222222222222")
        },
        new()
        {
            Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
            Date = DateTime.UtcNow.Date,
            Description = "Review support queue incidents",
            DepartmentId = 3,
            AssignedUserId = Guid.Parse("33333333-3333-3333-3333-333333333333")
        }
    ];

    public List<WorkTask> GetAll() => _tasks;

    public List<WorkTask> GetByDepartment(int departmentId)
        => _tasks.Where(t => t.DepartmentId == departmentId).ToList();

    public void Add(WorkTask task) => _tasks.Add(task);
}