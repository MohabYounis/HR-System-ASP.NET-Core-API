using HR_System.DataAccessLayer.Models;
using HR_System.HR.Core.Interfaces;
using HR_System.Repos.HrCon;
using HR_System.Repos.Repositories;

namespace HR_System.Repos.UnitOfWorks
{
    public class UnitOfWork : IBaseService
    {
        private readonly HrContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(HrContext context) => _context = context;

        // Generic method return repository of any entity 
        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class
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
