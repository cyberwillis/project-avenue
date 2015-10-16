using System.Web;
using NHibernate;

namespace AvenueEntrega.RepositoryNHibernate.SessionStorage
{
    public class HttpSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly string SessionKey = "NHSession";

        public ISession GetCurrentSession()
        {
            ISession nhSessiom = null;

            if (HttpContext.Current.Items.Contains((SessionKey)))
            {
                nhSessiom = (ISession)HttpContext.Current.Items[SessionKey];
            }

            return nhSessiom;

        }

        public void Store(ISession session)
        {
            if (HttpContext.Current.Items.Contains((SessionKey)))
            {
                HttpContext.Current.Items[SessionKey] = session;
            }
            else
            {
                HttpContext.Current.Items.Add(SessionKey, session);
            }
        }
    }
}