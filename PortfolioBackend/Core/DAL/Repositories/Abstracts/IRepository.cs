using PortfolioBackend.Entities;
using System.Linq.Expressions;

namespace PortfolioBackend.Core.DAL.Repositories.Abstracts
{
    public interface IRepository<T>
        where T : class,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> filter);
        Task SaveAsync();
    }
}
