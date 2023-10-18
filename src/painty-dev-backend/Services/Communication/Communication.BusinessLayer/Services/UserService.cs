using Communication.BusinessLayer.Data;
using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(AppDbContext context) : base(context) { }
        public override async Task<ICollection<User>> GetAsync() => await GetAsync(x => x.Role!);
        public async Task<User?> GetByNameAsync(string name) =>
            await GetAsync(x => x.Name == name, x => x.Role!, x => x.Images, x => x.SendToBeFriends,
                x => x.ReceiveToBeFriends);
        public override async Task<User?> GetAsync(Guid id) =>
            await GetAsync(x => x.Id == id, x => x.Role!, x => x.Images, x => x.SendToBeFriends,
                x => x.ReceiveToBeFriends);
    }
}
