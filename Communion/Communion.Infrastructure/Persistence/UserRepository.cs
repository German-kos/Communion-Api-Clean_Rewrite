using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.Entities;

namespace Communion.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetByUsername(string username)
    {
        return _users.SingleOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
    }

    public bool DoesEmailExist(string email)
    {
        return _users.Any(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
    }

    public bool DoesUsernameExist(string username)
    {
        return _users.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
    }
}