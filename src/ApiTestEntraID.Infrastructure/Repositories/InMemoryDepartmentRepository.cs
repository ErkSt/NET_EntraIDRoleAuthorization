using ApiTestEntraID.Application.Interfaces;
using ApiTestEntraID.Domain.Entities;

namespace ApiTestEntraID.Infrastructure.Repositories;

public sealed class InMemoryDepartmentRepository : IDepartmentRepository
{
    private readonly List<Department> _departments =
    [
        new() { Id = 1, Name = "Documentation" },
        new() { Id = 2, Name = "Human Resources" },
        new() { Id = 3, Name = "Support" }
    ];

    public List<Department> GetAll() => _departments;

    public Department? GetById(int id) => _departments.FirstOrDefault(d => d.Id == id);
}