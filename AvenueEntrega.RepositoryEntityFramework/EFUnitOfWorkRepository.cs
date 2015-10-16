using System.Data.Entity;
using AvenueEntrega.Model;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryEntityFramework
{
    public class EFUnitOfWorkRepository<TEntity, TContext> : IUnitOfWorkRepository<TEntity> where TEntity : class, IAggregateRoot where TContext : DbContext
    {
        public void SaveCreated(TEntity entity)
        {
            DataContextFactory<TContext>.GetDataContext().Set<TEntity>().Add((TEntity)entity);
        }

        public void SaveAmended(TEntity entity)
        {
            DataContextFactory<TContext>.GetDataContext().Entry(entity).State = EntityState.Modified;
        }

        public void SaveDeleted(TEntity entity)
        {
            DataContextFactory<TContext>.GetDataContext().Set<TEntity>().Remove((TEntity)entity);
        }

        public void Persist()
        {
            DataContextFactory<TContext>.GetDataContext().SaveChanges();
        }
    }
}