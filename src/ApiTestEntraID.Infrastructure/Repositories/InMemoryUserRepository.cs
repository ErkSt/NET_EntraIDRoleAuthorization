using ApiTestEntraID.Application.Interfaces;
using ApiTestEntraID.Domain.Entities;

namespace ApiTestEntraID.Infrastructure.Repositories;

public sealed class InMemoryUserRepository : IUserRepository
{
    private readonly List<AppUser> _users =
    [
        new()
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            FullName = "Alice Documentation",
            Email = "alice@demo.local",
            Password = "Pass123!"
        },
        new()
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            FullName = "Bob HR",
            Email = "bob@demo.local",
            Password = "Pass123!"
        },
        new()
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            FullName = "Charlie Support",
            Email = "charlie@demo.local",
            Password = "Pass123!"
        }
    ];

    public List<AppUser> GetAll() => _users;

    public AppUser? GetById(Guid id) => _users.FirstOrDefault(u => u.Id == id);
}