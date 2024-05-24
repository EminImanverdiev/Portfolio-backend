using Microsoft.EntityFrameworkCore;
using PortfolioBackend.Entities;
using PortfolioBackend.Repositories.EFcore;
using System.Linq.Expressions;

namespace PortfolioBackend.Core.DAL.Repositories.Concretes.EFCore
{
    public abstract class EfBaseRepository<TEntity,TContext>
        where TEntity : class,new()
        where TContext:DbContext
    {
        private readonly TContext _context;
        public EfBaseRepository(TContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>().ToListAsync()
                : _context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().AnyAsync(filter);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity about)
        {
            _context.Set<TEntity>().Update(about);
        }

    }
}
