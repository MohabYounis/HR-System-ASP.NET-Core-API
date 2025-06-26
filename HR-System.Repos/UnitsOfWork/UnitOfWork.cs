using HR_System.Core.Entities;
using HR_System.Core.Repositories.Contract;
using HR_System.Core.UnitsOfWork.Contract;
using HR_System.Repos.HrCon;
using HR_System.Repos.Repositories;

namespace HR_System.Repos.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HrContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(HrContext context) => _context = context;

        // Generic method return repository of any entity 
        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            // Define the type of entity
            var type = typeof(TEntity);

            // If the dictionary doesn't have any repository of this type => create one
            if (!_repositories.ContainsKey(type))
                _repositories[type] = new BaseRepository<TEntity>(_context); 

            // If else => return the exist obj and don't create new one
            return (IBaseRepository<TEntity>)_repositories[type];
        }
        
        public async Task SaveInDBAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
