using HR_System.DataAccessLayer.Models;
using HR_System.HR.Core.Interfaces;

namespace HR_System.Repos.UnitOfWorks
{
    public interface IBaseService : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task SaveInDBAsync();
    }
}
