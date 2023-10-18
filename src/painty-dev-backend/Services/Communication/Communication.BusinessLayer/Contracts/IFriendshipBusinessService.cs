using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Contracts
{
    public interface IFriendshipBusinessService
    {
        Task<ICollection<User>> FindFriend();
        Task<Friendship?> GetFriendshipAsync(Guid id);
        Task CreateFriendshipAsync(FriendshipDto friendshipDto);
        Task ConfirmFriendshipAsync(FriendshipDto friendshipDto);
    }
}
