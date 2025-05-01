using Ecommerce_mvc.Models;
using System.Linq.Expressions;

namespace Ecommerce_mvc.IRepository
{
    public interface IGenricRepository<T> where T:class,IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity,int id);
        Task Deleteasync(int id);

    }
}
