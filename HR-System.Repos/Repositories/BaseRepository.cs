using HR_System.HR.Core.Interfaces;
using HR_System.Repos.HrCon;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR_System.Repos.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly HrContext _context;
        public BaseRepository(HrContext context) => _context = context;
        

        public IQueryable<TEntity> GetAllAsync() =>_context.Set<TEntity>().AsQueryable();
        public IQueryable<TEntity> GetExistAsync() =>_context.Set<TEntity>().AsQueryable().Where(e=>!EF.Property<bool>(e,"IsDeleted"));
        public IQueryable<TEntity> GetAllWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null)
        {
            var query = GetAllAsync();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).AsQueryable();
        }
        public IQueryable<TEntity> GetExistWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null)
        {
            var query = GetExistAsync();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);
        public async Task<TEntity> GetItemAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null)
        {
            var query = GetAllAsync();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        public void Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException("Entity not found");

            var property = entity.GetType().GetProperty("IsDeleted");
            if (property != null && property.PropertyType == typeof(bool))
            {
                var isDeleted = (bool)property.GetValue(entity);
                if (isDeleted)
                {
                    throw new Exception("Entity is already deleted");
                }
                else
                {
                    property.SetValue(entity, true);
                    Update(entity);
                }
            }
        }
    }
}
