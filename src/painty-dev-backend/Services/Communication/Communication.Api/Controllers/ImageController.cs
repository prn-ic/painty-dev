using Communication.Api.Common;
using Communication.BusinessLayer.Contracts;
using Communication.DomainLayer.Dtos;
using Communication.DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaintyDev.Libs.CustomResponseLib;
using System.Security.Claims;

namespace Communication.Api.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageBusinessService _imageService;
        private Guid UserId => new Guid(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
            .FirstOrDefault()?.Value!);

        public ImageController(IImageBusinessService imageService) => _imageService = imageService;

        [HttpGet]
        [Authorize(Roles = AccessRoles.All)]
        public async Task<IActionResult> Get()
        {
            IReadOnlyCollection<Image> images = await _imageService.GetUserImagesAsync(UserId);
            return CustomResponse.OkResult(images);
        }

        [HttpGet("friend/{friendId}")]
        [Authorize(Roles = AccessRoles.All)]
        public async Task<IActionResult> Get(Guid friendId)
        {
            IReadOnlyCollection<Image> images = await _imageService.GetFriendImagesAsync(UserId, friendId);
            return CustomResponse.OkResult(images);
        }

        [HttpPost]
        [Authorize(Roles = AccessRoles.All)]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _imageService.UploadAsync(file, UserId);
            return CustomResponse.AcceptedResult();
        }
    }
}
