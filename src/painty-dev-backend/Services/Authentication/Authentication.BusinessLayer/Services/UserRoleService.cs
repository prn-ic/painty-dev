using Authentication.BusinessLayer.Data;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Entities;

namespace Authentication.BusinessLayer.Services
{
    public class UserRoleService : GenericService<UserRole>, IUserRoleService
    {
        public UserRoleService(AppDbContext context) : base(context) { }
        public async Task<UserRole?> GetByNameAsync(string name) =>
            await GetAsync(x => x.Name == name);
    }
}
