using System.Collections.Generic;
using AvenueEntrega.Model;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryMongoDB.Repositories
{
    public class RepositoryBase<TEntity,TId> : IRepository<TEntity,TId> where TEntity : IAggregateRoot
    {
        private IUnitOfWork<TEntity> _unitOfWork;

        public RepositoryBase(IUnitOfWork<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<TEntity> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public TEntity FindBy(TId id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Persist()
        {
            throw new System.NotImplementedException();
        }
    }
}