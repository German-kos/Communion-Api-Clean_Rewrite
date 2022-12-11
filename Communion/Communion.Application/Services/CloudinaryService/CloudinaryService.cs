using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Communion.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Communion.Application.Services.CloudinaryService;

public class ImageService : IImageService
{
    // Dependency Injections:
    private readonly Cloudinary _cloudinary;
    public ImageService(IOptions<CloudinarySettings> config)
    {
        _cloudinary = new Cloudinary(
            new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret));
    }

    // Methods:

    public async Task<DeletionResult> DeleteImageAsync(string publicId)
    {
        var deletionParams = new DeletionParams(publicId);

        return await _cloudinary.DestroyAsync(deletionParams);
    }

    public async Task<ImageUploadResult> UploadBannerAsync(IFormFile imageFile)
    {
        ImageUploadResult imageUploadResult = new();

        if (imageFile.Length > 0)
        {
            using var stream = imageFile.OpenReadStream();
            ImageUploadParams imageUploadParams = new()
            {
                File = new FileDescription(imageFile.FileName, stream),
                Transformation = new Transformation().Height(200).Width(600).Crop("fill")
            };

            imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);
        }

        return imageUploadResult;
    }

    public async Task<ImageUploadResult> UploadProfilePictureAsync(IFormFile imageFile)
    {
        ImageUploadResult imageUploadResult = new();

        if (imageFile.Length > 0)
        {
            using var stream = imageFile.OpenReadStream();
            ImageUploadParams imageUploadParams = new()
            {
                File = new FileDescription(imageFile.FileName, stream),
                Transformation = new Transformation().Height(200).Width(200).Crop("fill").Gravity("face")
            };

            imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);
        }

        return imageUploadResult;
    }
}
