using Microsoft.EntityFrameworkCore;
using MvcAppDemo.RazorPages.Data;
using MvcAppDemo.RazorPages.Repository.Interfaces;
using System.Linq.Expressions;

namespace MvcAppDemo.RazorPages.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context?.SaveChanges();
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> condition,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
                query = query.Include(include);

            var entity = await query.FirstOrDefaultAsync(condition);
            if (entity is null)
                return default!;
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context?.SaveChanges();
        }
    }
}
