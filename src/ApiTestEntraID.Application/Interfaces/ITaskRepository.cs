using ApiTestEntraID.Domain.Entities;

namespace ApiTestEntraID.Application.Interfaces;

public interface ITaskRepository
{
    List<WorkTask> GetAll();
    List<WorkTask> GetByDepartment(int departmentId);
    void Add(WorkTask task);
}