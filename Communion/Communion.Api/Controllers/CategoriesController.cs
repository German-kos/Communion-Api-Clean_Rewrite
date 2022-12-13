using Communion.Api.Extensions;
using Communion.Application.Categories.Commands.CreateCategory;
using Communion.Application.Categories.Commands.CreateTopic;
using Communion.Application.Categories.Commands.EditCategory;
using Communion.Application.Categories.Commands.RenameTopic;
using Communion.Application.Common.Interfaces.Services;
using Communion.Contracts.Categories;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
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

    [HttpPost("Create-Category")]
    [Authorize]
    public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryRequest request)
    {
        var username = User.GetUsername();

        var uploadBannerResult = await _imageService.UploadBannerAsync(request.BannerImage);

        var command = _mapper.Map<CreateCategoryCommand>((request, username, uploadBannerResult.PublicId, uploadBannerResult.SecureUrl.AbsoluteUri));

        return await ReturnCommandResult(command);
    }

    // VVV Reminder VVV
    // *** Implement check for admin rights when database is added ***

    // JWT and admin rights are needed
    [HttpPost("Edit-Category")] // POST api/admin/categories/edit-category
    public async Task<IActionResult> EditCategory([FromForm] EditCategoryRequest request)
    {
        string username = User.GetUsername()!;

        string? newBannerPublicId = null;
        string? newBannerUrl = null;

        if (request.NewBannerImage is not null)
        {
            var uploadBannerResult = await _imageService.UploadBannerAsync(request.NewBannerImage);
            newBannerPublicId = uploadBannerResult.PublicId;
            newBannerUrl = uploadBannerResult.SecureUrl.AbsoluteUri;
        }

        var command = _mapper.Map<EditCategoryCommand>((request, newBannerPublicId, newBannerUrl, username));

        return await ReturnCommandResult(command);
    }

    // JWT and admin rights are needed
    [HttpPost("Create-Topic")] // POST /api/admin/categories/create-topic
    public async Task<IActionResult> CreateTopic([FromForm] CreateTopicRequest request)
    {
        string username = User.GetUsername()!;

        var command = _mapper.Map<CreateTopicCommand>((request, username));

        return await ReturnCommandResult(command);

    }

    // JWT and admin rights are needed
    [HttpPost("Rename-Topic")] // POST /api/admin/categories/remove-topic
    public async Task<IActionResult> RenameTopic([FromForm] RenameTopicRequest request)
    {
        string username = User.GetUsername()!;

        var command = _mapper.Map<RenameTopicCommand>((request, username));

        return await ReturnCommandResult(command);
    }

    // Command send & return handler
    private async Task<IActionResult> ReturnCommandResult(IRequest<ErrorOr<Category>> command)
    {
        var renameTopicResult = await _mediator.Send(command);

        return renameTopicResult.Match(
            category => Ok(_mapper.Map<CategoryResponse>(category)),
            errors => Problem(errors));
    }
}