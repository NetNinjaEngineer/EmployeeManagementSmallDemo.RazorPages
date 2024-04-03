using System.Linq.Expressions;

namespace MvcAppDemo.RazorPages.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<T> FindByConditionAsync(Expression<Func<T, bool>> condition,
            params Expression<Func<T, object>>[] includes);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
