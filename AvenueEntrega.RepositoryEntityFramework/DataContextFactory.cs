using System;
using System.Data.Entity;
using AvenueEntrega.RepositoryEntityFramework.DataContextStorage;

namespace AvenueEntrega.RepositoryEntityFramework
{
    public class DataContextFactory<TContext> where TContext : DbContext
    {
        public static TContext GetDataContext()
        {
            IDataContextStorageContainer dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();

            TContext dataContext = (TContext)dataContextStorageContainer.GetDataContext();
            if (dataContext == null)
            {
                dataContext = Activator.CreateInstance<TContext>();
                dataContextStorageContainer.Store(dataContext);
            }

            return dataContext;
        }
    }
}
