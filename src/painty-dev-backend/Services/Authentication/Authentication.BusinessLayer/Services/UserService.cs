using Authentication.BusinessLayer.Data;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Entities;

namespace Authentication.BusinessLayer.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(AppDbContext context) : base(context) { }
        public async Task<User> GetByNameAsync(string name) => await GetAsync(x => x.Name == name);
    }
}
