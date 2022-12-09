using Communion.Application.Categories.Commands.CreateCategory;
using Communion.Contracts.Categories;
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
    }
}
