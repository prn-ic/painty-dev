using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;
namespace Communication.BusinessLayer.Contracts
{
    public interface IFriendshipBusinessService
    {
        Task<Friendship?> GetFriendshipAsync(Guid id);
        Task CreateFriendshipAsync(FriendsipDto friendshipDto);
    }
}
