using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[ApiController]
public class NameController : ApiController
{
    [HttpGet]
    public IActionResult ListCategories()
    {
        return Ok();
    }
}