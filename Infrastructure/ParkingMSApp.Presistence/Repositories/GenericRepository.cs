using Microsoft.EntityFrameworkCore;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Domain.Common;
using ParkingMSApp.Presistence.Context;
using System.Linq.Expressions;

namespace ParkingMSApp.Presistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T model)
        {
            await _dbSet.AddAsync(model);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            
        }
    }
}
