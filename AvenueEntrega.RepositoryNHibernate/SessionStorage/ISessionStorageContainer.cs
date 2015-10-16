using NHibernate;

namespace AvenueEntrega.RepositoryNHibernate.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}