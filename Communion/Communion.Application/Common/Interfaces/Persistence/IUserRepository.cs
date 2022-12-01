using Communion.Domain.Entities;

namespace Communion.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetByUsername(string username);
}