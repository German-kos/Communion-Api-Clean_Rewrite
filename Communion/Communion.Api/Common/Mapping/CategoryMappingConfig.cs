using Communion.Application.Categories.Commands.CreateCategory;
using Communion.Application.Categories.Commands.CreateTopic;
using Communion.Application.Categories.Commands.EditCategory;
using Communion.Application.Categories.Commands.RenameCategory;
using Communion.Application.Categories.Commands.RenameTopic;
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
        config.NewConfig
                <(CreateCategoryRequest Request,
                    string Username,
                    string BannerPublicId,
                    string BannerUrl),
                CreateCategoryCommand>()
            .Map(dest => dest.Username, src => src.Username)
            .Map(dest => dest.BannerPublicId, src => src.BannerPublicId)
            .Map(dest => dest.BannerUrl, src => src.BannerUrl)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Category, CategoryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Banner, BannerResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Topic, TopicResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CategoryId, src => src.CategoryId.Value);

        config.NewConfig
                <(RenameCategoryRequest Request,
                    string Username),
                RenameCategoryCommand>()
            .Map(dest => dest.CategoryId, src => new Guid(src.Request.CategoryId))
            .Map(dest => dest.NewName, src => src.Request.NewName)
            .Map(dest => dest.Username, src => src.Username);

        config.NewConfig
                <(EditCategoryRequest Request,
                    string? NewBannerPublicId,
                    string? NewBannerUrl,
                    string Username),
                EditCategoryCommand>()
            .Map(dest => dest.CategoryId, src => new Guid(src.Request.CategoryId))
            .Map(dest => dest.NewName, src => src.Request.NewName)
            .Map(dest => dest.NewBannerPublicId, src => src.NewBannerPublicId)
            .Map(dest => dest.NewBannerUrl, src => src.NewBannerUrl)
            .Map(dest => dest.Username, src => src.Username);

        config.NewConfig
                <(CreateTopicRequest Request,
                    string Username),
                CreateTopicCommand>()
            .Map(dest => dest.CategoryId, src => new Guid(src.Request.CategoryId))
            .Map(dest => dest.TopicName, src => src.Request.TopicName)
            .Map(dest => dest.Username, src => src.Username);

        config.NewConfig
                <(RenameTopicRequest Request,
                    string Username),
                RenameTopicCommand>()
            .Map(dest => dest.CategoryId, src => new Guid(src.Request.CategoryId))
            .Map(dest => dest.TopicId, src => new Guid(src.Request.TopicId))
            .Map(dest => dest.NewTopicName, src => src.Request.NewTopicName)
            .Map(dest => dest.Username, src => src.Username);
    }
}
