using Communication.BusinessLayer.Data;
using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(AppDbContext context) : base(context) { }
        public async Task<User?> GetByNameAsync(string name) =>
            await GetAsync(x => x.Name == name, x => x.Role!, x => x.Images, x => x.Friends);
        public override async Task<User?> GetAsync(Guid id) =>
            await GetAsync(x => x.Id == id, x => x.Role!, x => x.Images, x => x.Friends);
    }
}
