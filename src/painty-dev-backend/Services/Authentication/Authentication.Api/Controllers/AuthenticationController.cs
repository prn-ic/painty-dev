using Authentication.BusinessLayer.Contracts;
using Authentication.BusinessLayer.Models;
using Authentication.DomainLayer.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaintyDev.Libs.CustomResponseLib;

namespace Authentication.Api.Controllers
{
    [Route("api.paintly/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService) =>
            _authenticationService = authenticationService;

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] UserDto userDto)
        {
            TokenModel tokens = await _authenticationService.SignInAsync(userDto);
            return CustomResponse.OkResult(tokens);
        }

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserDto userDto)
        {
            TokenModel tokens = await _authenticationService.SignUpAsync(userDto);
            return CustomResponse.OkResult(tokens);
        }

        [HttpGet("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken(string token)
        {
            TokenModel tokens = await _authenticationService.RefreshAsync(token);
            return CustomResponse.OkResult(tokens);
        }
    }
}
