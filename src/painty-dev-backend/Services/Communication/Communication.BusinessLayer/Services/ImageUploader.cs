using Communication.BusinessLayer.Contracts;
using Microsoft.AspNetCore.Http;

namespace Communication.BusinessLayer.Services
{
    public class ImageUploader : IImageUploader
    {
        public bool Upload(IFormFile fileInfo, string path, string filename)
        {
            if (fileInfo is null) return false;
            string fullPath = path + filename;
            CreateFolderIfNotExist(path);

            using FileStream fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
            
            Task.Run(async () => await fileInfo.CopyToAsync(fileStream)).Wait();

            return true;
        }

        public static void CreateFolderIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
