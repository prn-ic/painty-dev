using Authentication.DomainLayer.Entities;

namespace Authentication.DomainLayer.Contracts
{
    public interface IUserService : IGenericService<User>
    {
        Task<User?> GetByNameAsync(string name);
    }
}
