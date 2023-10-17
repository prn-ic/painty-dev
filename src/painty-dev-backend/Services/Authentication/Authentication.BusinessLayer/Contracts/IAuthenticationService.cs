using Authentication.BusinessLayer.Models;
using Authentication.DomainLayer.Dtos;

namespace Authentication.BusinessLayer.Contracts
{
    public interface IAuthenticationService
    {
        Task<TokenModel> SignInAsync(UserDto userDto);
        Task<TokenModel> SignUpAsync(UserDto userDto);
        Task<TokenModel> RefreshAsync(string token);
    }
}
