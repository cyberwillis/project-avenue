using AvenueEntrega.Model;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryEntityFramework
{
    public class EFUnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : IAggregateRoot
    {
        private IUnitOfWorkRepository<TEntity> _unitOfWorkRepository;

        public EFUnitOfWork(IUnitOfWorkRepository<TEntity> unitOfWorkRepository)
        {
            this._unitOfWorkRepository = unitOfWorkRepository;
        }

        public void Save(TEntity entity)
        {
            this._unitOfWorkRepository.SaveCreated(entity);
        }

        public void Update(TEntity entity)
        {
            this._unitOfWorkRepository.SaveAmended(entity);
        }

        public void Remove(TEntity entity)
        {
            this._unitOfWorkRepository.SaveDeleted(entity);
        }

        public void Commit()
        {
            this._unitOfWorkRepository.Persist();
        }
    }
}