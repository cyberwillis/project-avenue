using System.Collections;
using System.Threading;
using NHibernate;

namespace AvenueEntrega.RepositoryNHibernate.SessionStorage
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly Hashtable NHSessions = new Hashtable();

        public ISession GetCurrentSession()
        {
            ISession nhSession = null;

            var threadName = GetThreadName();

            if (NHSessions.Contains(threadName))
            {
                nhSession = (ISession)NHSessions[threadName];
            }

            return nhSession;
        }

        private object GetThreadName()
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "NHThread";

            return Thread.CurrentThread.Name;
        }

        public void Store(ISession session)
        {
            var threadName = GetThreadName();

            if (NHSessions.Contains(threadName))
                NHSessions[threadName] = session;
            else
                NHSessions.Add(threadName, session);
        }
    }
}