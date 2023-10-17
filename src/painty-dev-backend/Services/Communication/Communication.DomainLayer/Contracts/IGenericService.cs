using System.Linq.Expressions;

namespace Communication.DomainLayer.Contracts
{
    public interface IGenericService<T>
    {
        Task<ICollection<T>> GetAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> expression,
            params Expression<Func<T, object>>[] expressionList);
        Task<T?> GetAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
