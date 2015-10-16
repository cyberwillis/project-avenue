using System.Collections;
using System.Data.Entity;
using System.Threading;

namespace AvenueEntrega.RepositoryEntityFramework.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable DataContexts = new Hashtable();

        public DbContext GetDataContext()
        {
            DbContext dataContext = null;

            var threadname = GetThreadName();

            if (DataContexts.Contains(GetThreadName()))
                dataContext = (DbContext)DataContexts[threadname];

            return dataContext;
        }

        public void Store(DbContext dataContext)
        {
            var threadName = GetThreadName();

            if (DataContexts.Contains(threadName))
                DataContexts[threadName] = dataContext;
            else
                DataContexts.Add(threadName, dataContext);
        }

        private static string GetThreadName()
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "EFThread";

            return Thread.CurrentThread.Name;
        }
    }
}