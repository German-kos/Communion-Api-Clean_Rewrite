using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Communion.Application.Common.Interfaces.Services;

public interface IImageService
{
    Task<ImageUploadResult> UploadProfilePictureAsync(IFormFile imageFile);
    Task<ImageUploadResult> UploadBannerAsync(IFormFile imageFile);
    Task<DeletionResult> DeleteImageAsync(string publicId);
}