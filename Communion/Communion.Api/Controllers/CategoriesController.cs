using System.Security.Claims;
using Communion.Api.Extensions;
using Communion.Application.Categories.Commands.CreateCategory;
using Communion.Contracts.Categories;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[ApiController]
[Route("api/admin/categories")]
public class CategoriesController : ApiController
{
    private ISender _mediator;
    private readonly IMapper _mapper;
    public CategoriesController(IMapper mapper, ISender mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ListCategories()
    {
        return Ok(Array.Empty<string>());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryRequest request)
    {
        // Temporary values to resolve the IFormFile enumeration problem, remove after fixing with with Cloudinary middleware (remove from command line as well)
        string tempId = "TempId";
        string tempUrl = "TempUrl";

        var command = _mapper.Map<CreateCategoryCommand>((request, User.GetUsername(), tempId, tempUrl));

        var createCategoryResult = await _mediator.Send(command);
        return Ok(createCategoryResult);
    }
}