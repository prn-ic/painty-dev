using Communication.DomainLayer.Entities;

namespace Communication.DomainLayer.Dtos
{
    public class FriendshipDto : EntityBase
    {
        public Guid RequestFromId { get; set; }
        public Guid RequestToId { get; set; }
    }
}
