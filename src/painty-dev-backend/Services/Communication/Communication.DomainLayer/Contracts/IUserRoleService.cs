using Communication.DomainLayer.Entities;

namespace Communication.DomainLayer.Contracts
{
    public interface IUserRoleService : IGenericService<UserRole>
    {
        Task<UserRole?> GetByNameAsync(string name);
    }
}
