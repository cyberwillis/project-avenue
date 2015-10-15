using System.Collections.Generic;

namespace AvenueEntrega.Model.Repository
{
    public interface IRepository<TEntity, TId> where TEntity : IAggregateRoot
    {
        IList<TEntity> FindAll();
        TEntity FindBy(TId id);


        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Persist();
    }
}