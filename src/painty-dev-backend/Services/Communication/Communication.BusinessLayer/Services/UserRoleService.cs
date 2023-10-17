using Communication.BusinessLayer.Data;
using Communication.DomainLayer.Contracts;
using Communication.DomainLayer.Entities;

namespace Communication.BusinessLayer.Services
{
    public class UserRoleService : GenericService<UserRole>, IUserRoleService
    {
        public UserRoleService(AppDbContext context) : base(context) { }
        public async Task<UserRole?> GetByNameAsync(string name) =>
            await GetAsync(x => x.Name == name);
    }
}
