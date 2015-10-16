using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.Model;
using AvenueEntrega.Model.Repository;
using NHibernate.Linq;

namespace AvenueEntrega.RepositoryNHibernate.Repositories
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
            return SessionFactory.GetCurrentSession().Query<TEntity>().ToList();
        }

        public TEntity FindBy(TId id)
        {
            return SessionFactory.GetCurrentSession().Get<TEntity>(id);
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