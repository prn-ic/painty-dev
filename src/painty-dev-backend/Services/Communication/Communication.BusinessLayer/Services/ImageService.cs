using Communication.BusinessLayer.Data;
using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Services
{
    public class ImageService : GenericService<Image>, IImageService
    {
        public ImageService(AppDbContext context) : base(context) { }
        public override async Task<Image?> GetAsync(Guid id) =>
            await GetAsync(x => x.Id == id, x => x.User!);
    }
}
