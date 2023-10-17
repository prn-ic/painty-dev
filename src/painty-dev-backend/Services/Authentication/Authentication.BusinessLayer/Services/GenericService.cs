using Authentication.BusinessLayer.Data;
using Authentication.DomainLayer.Contracts;
using Authentication.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Authentication.BusinessLayer.Services
{
    public class GenericService<T> : IGenericService<T> where T : EntityBase
    {
        private readonly AppDbContext _context;
        public GenericService(AppDbContext context) => _context = context;
        public async Task CreateAsync(T entity)
        {
            T? entityExist = await _context.Set<T>().FirstOrDefaultAsync(r => r.Equals(entity));
            if (entityExist is not null)
                throw new InvalidOperationException("The entity already exist");

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            T? entityExist = await _context.Set<T>().FirstOrDefaultAsync(r => r.Id == id);
            if (entityExist is null)
                throw new InvalidDataException("The entity doesn't exist");

            _context.Set<T>().Remove(entityExist);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAsync() => await _context.Set<T>().ToListAsync();
        public async Task<T> GetAsync(Guid id) => await GetAsync(x => x.Id == id);

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            T? entityExist = await _context.Set<T>().FirstOrDefaultAsync(expression);
            if (entityExist is null)
                throw new InvalidDataException("The entity doesn't exist");

            return entityExist;
        }

        public async Task UpdateAsync(T entity)
        {
            T? entityExist = await _context.Set<T>().FirstOrDefaultAsync(r => r.Id == entity.Id);
            if (entityExist is null)
                throw new InvalidDataException("The entity doesn't exist");

            _context.Entry(entityExist).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }
}
