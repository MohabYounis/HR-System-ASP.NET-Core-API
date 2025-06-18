using HR_System.Repos.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Services.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetExistAsync();
        Task<IEnumerable<TEntity>> GetAllAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null);
        Task<IEnumerable<TEntity>> GetExistAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null);

        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetItemAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null);

        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(int id);
        Task SaveInDBAsync();
    }
}
