using HR_System.Core.Entities;
using HR_System.Core.Specifications;

namespace HR_System.Core.Services.Contract
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetExistAsync();
        Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> spec);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetItemWithSpecAsync(ISpecifications<TEntity> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> GetCountAsync(ISpecifications<TEntity> spec);
        Task SaveInDBAsync();
    }
}
