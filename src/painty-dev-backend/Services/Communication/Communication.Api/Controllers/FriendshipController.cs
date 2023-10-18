using Communication.Api.Common;
using Communication.BusinessLayer.Contracts;
using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaintyDev.Libs.CustomResponseLib;

namespace Communication.Api.Controllers
{
    [Route("api.paintly/friendships")]
    [ApiController]
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipBusinessService _friendshipService;
        public FriendshipController(IFriendshipBusinessService friendshipService) =>
            _friendshipService = friendshipService;

        [HttpGet("users")]
        [Authorize(Roles = AccessRoles.All)]
        public async Task<IActionResult> FindFriends()
        {
            ICollection<User> users = await _friendshipService.FindFriend();
            return CustomResponse.OkResult(users);
        }

        [HttpPost]
        [Authorize(Roles = AccessRoles.All)]
        public async Task<IActionResult> Create(FriendshipDto friendshipDto)
        {
            await _friendshipService.CreateFriendshipAsync(friendshipDto);
            return CustomResponse.OkResult(friendshipDto);
        }

        [HttpPut("confirm")]
        [Authorize(Roles = AccessRoles.All)]
        public async Task<IActionResult> ConfirmFriendship(FriendshipDto friendshipDto)
        {
            await _friendshipService.ConfirmFriendshipAsync(friendshipDto);
            return CustomResponse.OkResult(friendshipDto);
        }
    }
}
