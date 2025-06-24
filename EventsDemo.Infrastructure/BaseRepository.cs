using Events.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Events.Infrastructure
{
    public abstract class BaseRepository<T> where T : class
    {
        #region Protected
        protected EventsDbContext _context;
        protected DbSet<T> _dbSet;

        protected IQueryable<T> Table => _dbSet;
        protected IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        #endregion

        #region ctor
        public BaseRepository(EventsDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task BaseAddAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity, token);
            await _context.SaveChangesAsync(token);
        }
        public async Task<T> BaseGetAsync(CancellationToken token, params object[] key)
        {
            return await _dbSet.FindAsync(key, token);
        }
        public async Task<List<T>> BaseGetAllAsync(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token);
        }
        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return _dbSet.AnyAsync(predicate, token);
        }
        public async Task BaseUpdateAsync(T entity, CancellationToken token)
        {
            if (entity == null)
                return;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(token);
        }
        public async Task BaseDeleteAsync(T result, CancellationToken token)
        {
            _dbSet.Remove(result);

            await _context.SaveChangesAsync(token);
        }
        #endregion

    }
}
