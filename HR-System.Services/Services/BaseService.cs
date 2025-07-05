using HR_System.Core.Entities;
using HR_System.Core.Services.Contract;
using HR_System.Core.Specifications;
using HR_System.Core.UnitsOfWork.Contract;

namespace HR_System.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _unitOfWork.Repository<TEntity>().GetAllAsync();

        public async Task<IReadOnlyList<TEntity>> GetExistAsync()
            => await _unitOfWork.Repository<TEntity>().GetExistAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity> spec)
            => await _unitOfWork.Repository<TEntity>().GetAllWithSpecAsync(spec);

        public async Task<TEntity> GetByIdAsync(int id)
            => await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);

        public async Task<TEntity> GetItemWithSpecAsync(ISpecifications<TEntity> spec)
            => await _unitOfWork.Repository<TEntity>().GetItemWithSpecAsync(spec);

        public async Task AddAsync(TEntity entity)
            => await _unitOfWork.Repository<TEntity>().AddAsync(entity);

        public async Task DeleteAsync(TEntity entity)
            => await _unitOfWork.Repository<TEntity>().DeleteAsync(entity);

        public void Update(TEntity entity)
            => _unitOfWork.Repository<TEntity>().Update(entity);

        public async Task<int> GetCountAsync(ISpecifications<TEntity> spec)
            => await _unitOfWork.Repository<TEntity>().GetCountAsync(spec);

        public async Task SaveInDBAsync()
            => await _unitOfWork.SaveInDBAsync();
    }
}
