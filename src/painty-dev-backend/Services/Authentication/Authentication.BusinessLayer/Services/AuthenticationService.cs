using Authentication.BusinessLayer.Contracts;
using Authentication.BusinessLayer.Exceptions;
using Authentication.BusinessLayer.MassTransit;
using Authentication.BusinessLayer.Models;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Dtos;
using Authentication.DomainLayer.Entities;
using EventBus.Entities.Users;
using System.Security.Claims;

namespace Authentication.BusinessLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IJwtService _jwtService;
        private readonly PublisherBase _publisher;

        public AuthenticationService(IUserService userService, IJwtService jwtService,
            IUserRoleService userRoleService, PublisherBase publisher)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _jwtService = jwtService;
            _publisher = publisher;
        }
        public async Task<TokenModel> RefreshAsync(string token)
        {
            ClaimsPrincipal principal = _jwtService.GetClaimsPrincipal(token);
            if (principal is null)
                throw new InvalidTokenException<User>();

            User? user = await _userService.GetByNameAsync(
                principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value);

            return _jwtService.CreateTokenPair(user!);
        }

        public async Task<TokenModel> SignInAsync(UserDto userDto)
        {
            User? user = await _userService.GetByNameAsync(userDto.Name!);

            if (user is null)
                throw new NotFoundException<User>();

            if (!user.Validate(userDto.Password!))
                throw new InvalidDataException<User>();

            return _jwtService.CreateTokenPair(user);
        }

        public async Task<TokenModel> SignUpAsync(UserDto userDto)
        {
            if (userDto.Name is null) throw new InvalidDataException<User>(new[] { "Name" });

            if (userDto.Password is null) throw new InvalidDataException<User>(new[] { "Password" });

            if (await _userService.GetByNameAsync(userDto.Name) is not null)
                throw new ConflictException<User>();

            UserRole? role = await _userRoleService.GetByNameAsync("user");
            User user = new User(userDto.Name, userDto.Password, role!);
            await _userService.CreateAsync(user);

            AuthCreateModel model = new AuthCreateModel();
            model.Id = user.Id;
            model.Name = user.Name;
            model.RoleName = role!.Name;

            await _publisher.Send(model);
            // Generate a confirmation token 
            return _jwtService.CreateTokenPair(user);
        }

    }
}
