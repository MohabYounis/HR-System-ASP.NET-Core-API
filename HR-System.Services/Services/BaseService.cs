using HR_System.Repos.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HR_System.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseService _unitOfWork;
        public BaseService(IBaseService unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _unitOfWork.Repository<TEntity>().GetAllAsync().ToListAsync();
        public async Task<IEnumerable<TEntity>> GetExistAsync() => await _unitOfWork.Repository<TEntity>().GetExistAsync().ToListAsync();
        public async Task<IEnumerable<TEntity>> GetExistAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null) => 
            await _unitOfWork.Repository<TEntity>().GetExistWithExpression(includes, criteria).ToListAsync();
        public async Task<IEnumerable<TEntity>> GetAllAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null) => 
            await _unitOfWork.Repository<TEntity>().GetAllWithExpression(includes, criteria).ToListAsync();


        public async Task<TEntity> GetByIdAsync(int id) => await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
        public async Task<TEntity> GetItemAsyncWithExpression(string[] includes = null, Expression<Func<TEntity, bool>> criteria = null) =>
            await _unitOfWork.Repository<TEntity>().GetItemAsyncWithExpression(includes, criteria);

        public async Task AddAsync(TEntity entity) => await _unitOfWork.Repository<TEntity>().AddAsync(entity);
        public async Task DeleteAsync(int id) => await _unitOfWork.Repository<TEntity>().DeleteAsync(id);
        public void Update(TEntity entity) => _unitOfWork.Repository<TEntity>().Update(entity);
        public async Task SaveInDBAsync() => await _unitOfWork.SaveInDBAsync();
    }
}
