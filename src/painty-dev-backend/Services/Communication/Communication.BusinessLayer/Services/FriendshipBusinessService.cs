using Communication.BusinessLayer.Contracts;
using Communication.BusinessLayer.Exceptions;
using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Services
{
    public class FriendshipBusinessService : IFriendshipBusinessService
    {
        private readonly IFriendshipService _friendshipService;
        private readonly IUserService _userService;

        public FriendshipBusinessService(IFriendshipService friendshipService, IUserService userService)
        {
            _friendshipService = friendshipService;
            _userService = userService;
        }

        public async Task ConfirmFriendshipAsync(FriendsipDto friendshipDto)
        {
            User? currentUser = await _userService.GetAsync(friendshipDto.RequestFromId);
            User? friendUser = await _userService.GetAsync(friendshipDto.RequestToId);
            Friendship? friendship = await _friendshipService.GetAsync(friendshipDto.Id);
            if (currentUser is null || friendUser is null) throw new NotFoundException<User>();

            if (friendship is null) throw new NotFoundException<User>();

            friendship.Approved = true;
            await _friendshipService.UpdateAsync(friendship);
        }

        public async Task CreateFriendshipAsync(FriendsipDto friendshipDto)
        {
            User? currentUser = await _userService.GetAsync(friendshipDto.RequestFromId);
            User? friendUser = await _userService.GetAsync(friendshipDto.RequestToId);

            if (currentUser is null || friendUser is null) throw new NotFoundException<User>();

            if (await _friendshipService.GetAsync(friendshipDto.Id) is not null)
                throw new ConflictException<Friendship>("The friendship already exist");

            Friendship friendship = new Friendship(currentUser, friendUser);
            await _friendshipService.CreateAsync(friendship);
        }

        public async Task<ICollection<User>> FindFriend() => await _userService.GetAsync();

        public async Task<Friendship?> GetFriendshipAsync(Guid id)
        {
            Friendship? friendship = await _friendshipService.GetAsync(id);
            if (friendship is null)
                throw new NotFoundException<Friendship>();

            return friendship;
        }
    }
}
