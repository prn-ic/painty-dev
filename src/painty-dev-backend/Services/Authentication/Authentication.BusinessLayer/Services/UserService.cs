using Authentication.BusinessLayer.Data;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Entities;
using System.Xml.Linq;

namespace Authentication.BusinessLayer.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(AppDbContext context) : base(context) { }
        public async Task<User?> GetByNameAsync(string name) => 
            await GetAsync(x => x.Name == name, x => x.Role!);
        public override async Task<User?> GetAsync(Guid id) =>
            await GetAsync(x => x.Id == id, x => x.Role!);
    }
}
