using System;
using AvenueEntrega.Model;
using AvenueEntrega.Model.Repository;
using NHibernate;

namespace AvenueEntrega.RepositoryNHibernate
{
    public class NHUnitOfWorkRepository<TEntity> : IUnitOfWorkRepository<TEntity> where TEntity : IAggregateRoot
    {
        public void SaveCreated(TEntity entity)
        {
            SessionFactory.GetCurrentSession().Save(entity);
        }

        public void SaveAmended(TEntity entity)
        {
            SessionFactory.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void SaveDeleted(TEntity entity)
        {
            SessionFactory.GetCurrentSession().Delete(entity);
        }

        public void Persist()
        {
            using (ITransaction transaction = SessionFactory.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw new Exception(ex.Message);
                }
            }
        }
    }
}