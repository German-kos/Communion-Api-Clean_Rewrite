using Communion.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : BaseApiController
{
    [HttpPost("sign-up")]
    public IActionResult SignUp([FromForm] SignUpRequest request)
    {
        return Ok(request);
    }

    [HttpPost("sign-in")]
    public IActionResult SignIn([FromForm] SignInRequest request)
    {
        return Ok(request);
    }
}