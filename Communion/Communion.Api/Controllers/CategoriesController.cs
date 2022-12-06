using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[ApiController]
public class CategoriesController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult ListCategories()
    {
        return Ok(Array.Empty<string>());
    }
}