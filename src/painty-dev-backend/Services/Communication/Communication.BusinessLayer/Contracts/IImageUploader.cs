using Microsoft.Extensions.FileProviders;

namespace Communication.BusinessLayer.Contracts
{
    public interface IImageUploader
    {
        Task Upload(IFileInfo fileInfo);
    }
}
