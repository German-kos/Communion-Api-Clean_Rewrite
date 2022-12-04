using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    public IActionResult Problem(List<Error> errors)
    {
        return Problem();
    }
}