using ApiTestEntraID.Domain.Entities;

namespace ApiTestEntraID.Application.Interfaces;

public interface IDepartmentRepository
{
    List<Department> GetAll();
    Department? GetById(int id);
}