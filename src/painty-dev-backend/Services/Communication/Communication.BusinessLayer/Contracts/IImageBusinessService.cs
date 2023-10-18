using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace Communication.BusinessLayer.Contracts
{
    public interface IImageBusinessService
    {
        Task<IReadOnlyCollection<Image>> GetUserImagesAsync(Guid userId);
        Task<IReadOnlyCollection<Image>> GetFriendImagesAsync(Guid userId, Guid friendId);
        Task UploadAsync(IFormFile file, Guid userId);
    }
}
