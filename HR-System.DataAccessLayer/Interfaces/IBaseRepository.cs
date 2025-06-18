using System.Linq.Expressions;

namespace HR_System.HR.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllAsync();
        IQueryable<TEntity> GetExistAsync();
        IQueryable<TEntity> GetAllWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null);
        IQueryable<TEntity> GetExistWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetItemAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
    }
}
