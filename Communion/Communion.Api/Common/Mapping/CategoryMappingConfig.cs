using Communion.Application.Categories.Commands.CreateCategory;
using Communion.Contracts.Categories;
using Communion.Domain.Category.Entities;
using Communion.Domain.CategoryAggregate;
using Communion.Domain.CategoryAggregate.Entities;
using Mapster;

namespace Communion.Api.Common.Mapping;

public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateCategoryRequest Request, string Username, string tempId, string tempUrl), CreateCategoryCommand>()
            .Map(dest => dest.Username, src => src.Username)
            .Map(dest => dest.BannerPublicId, src => src.tempId) // Mapster cannot iterate with IFormFiles, add the Cloudinary service to upload images with an image service middleware
            .Map(dest => dest.BannerUrl, src => src.tempUrl) // Mapster cannot iterate with IFormFiles, add the Cloudinary service to upload images with an image service middleware
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Category, CategoryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Banner, BannerResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Topic, TopicResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CategoryId, src => src.CategoryId.Value);
    }
}
