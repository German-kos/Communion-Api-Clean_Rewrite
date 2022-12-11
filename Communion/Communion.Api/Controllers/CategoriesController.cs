using Communion.Api.Extensions;
using Communion.Application.Categories.Commands.CreateCategory;
using Communion.Application.Common.Interfaces.Services;
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
    // Dependency Injections:
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly IImageService _imageService;
    public CategoriesController(IMapper mapper, ISender mediator, IImageService imageService)
    {
        _imageService = imageService;
        _mediator = mediator;
        _mapper = mapper;
    }

    // Controllers:

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
        var username = User.GetUsername();

        var uploadBannerResult = await _imageService.UploadBannerAsync(request.BannerImage);

        var command = _mapper.Map<CreateCategoryCommand>((request, username, uploadBannerResult.PublicId, uploadBannerResult.SecureUrl.AbsoluteUri));

        var createCategoryResult = await _mediator.Send(command);

        return createCategoryResult.Match(
            category => Ok(_mapper.Map<CategoryResponse>(category)),
            errors => Problem(errors));
    }
}