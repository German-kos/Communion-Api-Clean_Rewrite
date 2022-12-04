using System.Security.Cryptography;
using System.Text;
using Communion.Domain.Entities;

namespace Communion.Application.Services.Password;

public class PasswordService : IPasswordService
{
    public EncryptionResult EncryptPassword(string password)
    {
        using var hmac = new HMACSHA512();

        return new EncryptionResult(
            hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            hmac.Key);
    }

    public bool PasswordsMatch(string password, User user)
    {
        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
            if (computedHash[i] != user.PasswordHash[i])
                return false;

        return true;
    }
}