using Communication.BusinessLayer.Data;
using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Services
{
    public class FriendshipService : GenericService<Friendship>, IFriendshipService
    {
        public FriendshipService(AppDbContext context) : base(context) { }
        public override async Task<Friendship?> GetAsync(Guid id) =>
            await GetAsync(x => x.Id == id, x => x.RequestFrom!, x => x.RequestTo!);
    }
}
