using Communion.Application.Services.Authentication.Common;
using ErrorOr;

namespace Communion.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> SignUp(string username, string password, string name, string email);
}