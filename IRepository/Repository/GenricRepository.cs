using Ecommerce_mvc.Data;
using Ecommerce_mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ecommerce_mvc.IRepository.Repository
{
    public class GenricRepository<T> : IGenricRepository<T> where T : class, IEntityBase, new()
    {
        public readonly AppDbContext _context;
        public GenricRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Deleteasync(int id)
        {
            var entry = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entry);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();


        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> quary = _context.Set<T>();
            //quary = includeProperties.Aggregate(quary, (current, includeProperty) => current.Include(includeProperties));
            quary = includeProperties.Aggregate(quary, (current, includeProperty) => current.Include(includeProperty));
            return await quary.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);



        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
             
            IQueryable<T> quary = _context.Set<T>();
            //quary = includeProperties.Aggregate(quary, (current, includeProperty) => current.Include(includeProperties));
            quary = includeProperties.Aggregate(quary, (current, includeProperty) => current.Include(includeProperty));
            return await quary.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity, int id)
        {

            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

    }
}
