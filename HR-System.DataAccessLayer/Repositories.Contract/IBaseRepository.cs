using HR_System.Core.Entities;
using HR_System.Core.Specifications;

namespace HR_System.Core.Repositories.Contract
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetExistAsync();
        Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> spec);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetItemWithSpecAsync(ISpecifications<TEntity> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
        Task<int> GetCountAsync(ISpecifications<TEntity> spec);
    }
}
