using System.Data.Entity;

namespace AvenueEntrega.RepositoryEntityFramework.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        DbContext GetDataContext();
        void Store(DbContext dataContext);
    }
}