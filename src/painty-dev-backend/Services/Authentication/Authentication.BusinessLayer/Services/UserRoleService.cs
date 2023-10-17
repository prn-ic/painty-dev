using Authentication.BusinessLayer.Data;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Entities;

namespace Authentication.BusinessLayer.Services
{
    public class UserRoleService : GenericService<UserRole>, IUserRoleService
    {
        public UserRoleService(AppDbContext context) : base(context) { }
    }
}
