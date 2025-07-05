using HR_System.Core.Entities;
using HR_System.Core.Repositories.Contract;
using HR_System.Core.Specifications;
using HR_System.Repos.HrCon;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Repos.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly HrContext _context;
        public BaseRepository(HrContext context) => _context = context;
        

        public async Task<IReadOnlyList<TEntity>> GetAllAsync() 
            => await _context.Set<TEntity>().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetExistAsync() 
            => await _context.Set<TEntity>().Where(e=>!EF.Property<bool>(e,"IsDeleted")).ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> spec) 
            => await SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), spec).ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id) 
            => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> GetItemWithSpecAsync(ISpecifications<TEntity> spec) 
            => await SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), spec).FirstOrDefaultAsync();

        public async Task AddAsync(TEntity entity) 
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) 
            => _context.Entry(entity).State = EntityState.Modified;

        public async Task DeleteAsync(TEntity entity)
        {
            var property = entity.GetType().GetProperty("IsDeleted");
            if (property != null && property.PropertyType == typeof(bool))
            {
                var isDeleted = (bool)property.GetValue(entity);
                if (!isDeleted)
                {
                    property.SetValue(entity, true);
                    Update(entity);
                }
            }
        }

        public async Task<int> GetCountAsync(ISpecifications<TEntity> spec)
            => await SpecificationEvaluator<TEntity>.GetQuery(_context.Set<TEntity>(), spec).CountAsync();
    }
}
