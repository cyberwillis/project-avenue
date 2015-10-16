using NHibernate;

namespace AvenueEntrega.RepositoryMongoDB.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}