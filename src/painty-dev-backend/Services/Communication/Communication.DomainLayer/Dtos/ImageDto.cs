using Communication.DomainLayer.Entities;

namespace Communication.DomainLayer.Dtos
{
    public class ImageDto : EntityBase
    {
        public string? ImagePath { get; set; }
        public Guid UserId { get; set; }
    }
}
