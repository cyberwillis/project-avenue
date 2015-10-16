using System.Data.Entity;
using System.Web;

namespace AvenueEntrega.RepositoryEntityFramework.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private const string DataContextKey = "DataContext";

        public DbContext GetDataContext()
        {
            DbContext efContext = null;
            if (HttpContext.Current.Items.Contains(DataContextKey))
            {
                efContext = (DbContext)HttpContext.Current.Items[DataContextKey];
            }
            return efContext;
        }

        public void Store(DbContext dataContext)
        {
            if (HttpContext.Current.Items.Contains(DataContextKey))
            {
                HttpContext.Current.Items[DataContextKey] = dataContext;
            }
            else
            {
                HttpContext.Current.Items.Add(DataContextKey, dataContext);
            }
        }
    }
}