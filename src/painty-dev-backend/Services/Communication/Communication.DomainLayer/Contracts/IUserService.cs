using Communication.DomainLayer.Entities;

namespace Communication.DomainLayer.Contracts
{
    public interface IUserService : IGenericService<User>
    {
        Task<User?> GetByNameAsync(string name);
    }
}
