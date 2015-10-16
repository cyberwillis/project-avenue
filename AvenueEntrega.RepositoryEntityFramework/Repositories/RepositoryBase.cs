using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AvenueEntrega.Model;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryEntityFramework.Repositories
{
    public class RepositoryBase<TEntity, TId, TContext> : IRepository<TEntity, TId> where TEntity : class, IAggregateRoot where TContext : DbContext
    {
        private IUnitOfWork<TEntity> _unitOfWork;

        public RepositoryBase(IUnitOfWork<TEntity> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<TEntity> FindAll()
        {
            return DataContextFactory<TContext>.GetDataContext().Set<TEntity>().ToList();
        }

        public TEntity FindBy(TId id)
        {
            return DataContextFactory<TContext>.GetDataContext().Set<TEntity>().Find(id);
        }

        public void Save(TEntity entity)
        {
            this._unitOfWork.Save(entity);
        }

        public void Update(TEntity entity)
        {
            this._unitOfWork.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this._unitOfWork.Remove(entity);
        }

        public void Persist()
        {
            this._unitOfWork.Commit();
        }
    }
}