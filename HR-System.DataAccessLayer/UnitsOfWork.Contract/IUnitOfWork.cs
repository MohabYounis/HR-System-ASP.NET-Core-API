using HR_System.Core.Entities;
using HR_System.Core.Repositories.Contract;

namespace HR_System.Core.UnitsOfWork.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task SaveInDBAsync();
    }
}
