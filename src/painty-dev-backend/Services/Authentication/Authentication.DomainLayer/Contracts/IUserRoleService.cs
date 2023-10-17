using Authentication.DomainLayer.Entities;

namespace Authentication.DomainLayer.Contracts
{
    public interface IUserRoleService : IGenericService<UserRole>
    {
        Task<UserRole?> GetByNameAsync(string name);
    }
}
