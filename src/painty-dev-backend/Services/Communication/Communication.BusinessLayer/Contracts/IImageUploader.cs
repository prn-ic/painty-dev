using Microsoft.AspNetCore.Http;

namespace Communication.BusinessLayer.Contracts
{
    public interface IImageUploader
    {
        bool Upload(IFormFile fileInfo, string path, string filename);
    }
}
