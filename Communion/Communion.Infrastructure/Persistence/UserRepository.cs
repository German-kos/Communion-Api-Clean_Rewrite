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
        return _users.SingleOrDefault(u => u.Username.ToLower() == username.ToLower());
    }


    public bool DoesEmailExist(string email)
    {
        return _users.Any(u => u.Email.ToLower() == email.ToLower());
    }


    public bool DoesUsernameExist(string username)
    {
        return _users.Any(u => u.Username.ToLower() == username.ToLower());
    }
}