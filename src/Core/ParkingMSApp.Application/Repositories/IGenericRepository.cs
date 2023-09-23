using ParkingMSApp.Domain.Common;
using System.Linq.Expressions;

namespace ParkingMSApp.Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void Update(T entity);
    }
}
