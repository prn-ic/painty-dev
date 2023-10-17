using Authentication.BusinessLayer.Contracts;
using Authentication.BusinessLayer.Exceptions;
using Authentication.BusinessLayer.Models;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Dtos;
using Authentication.DomainLayer.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.BusinessLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthenticationService(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }
        public async Task<TokenModel> RefreshAsync(string token)
        {
            ClaimsPrincipal principal = _jwtService.GetClaimsPrincipal(token);
            if (principal is null)
                throw new InvalidTokenException<User>();

            User? user= await _userService.GetByNameAsync(
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

            User user = new User(userDto.Name, userDto.Password);
            await _userService.CreateAsync(new User(userDto.Name, userDto.Password));

            // Generate a confirmation token 
            return _jwtService.CreateTokenPair(user);
        }

    }
}
