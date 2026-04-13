using ApiTestEntraID.Domain.Entities;

namespace ApiTestEntraID.Application.Interfaces;

public interface IUserRepository
{
    List<AppUser> GetAll();
    AppUser? GetById(Guid id);
}