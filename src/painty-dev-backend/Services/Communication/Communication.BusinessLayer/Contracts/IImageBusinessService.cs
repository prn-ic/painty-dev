using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Contracts
{
    public interface IImageBusinessService
    {
        Task<List<Image>> GetFriendImagesAsync(Guid friendId);
        Task UploadAsync(ImageDto imageDto);
    }
}
