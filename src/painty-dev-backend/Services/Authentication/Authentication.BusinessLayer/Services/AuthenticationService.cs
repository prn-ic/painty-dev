using Authentication.BusinessLayer.Contracts;
using Authentication.BusinessLayer.Models;
using Authentication.DomainLayer.Dtos;

namespace Authentication.BusinessLayer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<TokenModel> RefreshAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<TokenModel> SignInAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<TokenModel> SignUpAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
