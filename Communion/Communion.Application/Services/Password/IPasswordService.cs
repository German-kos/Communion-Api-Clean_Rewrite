using Communion.Domain.Entities;

namespace Communion.Application.Services.Password;

public interface IPasswordService
{
    EncryptionResult EncryptPassword(string password);
    bool PasswordsMatch(string password, User user);
}