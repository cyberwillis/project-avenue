using System;
using System.Reflection;
using AvenueEntrega.RepositoryNHibernate.SessionStorage;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace AvenueEntrega.RepositoryNHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static void Init()
        {
            try
            {
                var config = GetConfiguration(SchemaAutoAction.Validate); //Tenta validar o schema do banco de dados

                _sessionFactory = config.BuildSessionFactory();
            }
            catch (Exception)
            {
                var config = GetConfiguration(SchemaAutoAction.Create); //Cria o schema do banco de dados

                _sessionFactory = config.BuildSessionFactory();
            }
        }

        private static Configuration GetConfiguration(SchemaAutoAction automation)
        {
            //var dbLocation = AppDomain.CurrentDomain.BaseDirectory;

            var config = new Configuration();
            config.DataBaseIntegration(x =>
            {
                x.Dialect<MsSql2012Dialect>();
                x.SchemaAction = automation;

                //x.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + dbLocation + "\\AvenueEntrega.mdf;Initial Catalog=AvenueEntrega;Integrated Security=True";
                x.ConnectionStringName = "DefaultConnection";
                x.Driver<SqlClientDriver>();
                x.ConnectionProvider<DriverConnectionProvider>();

                x.LogFormattedSql = true;
                x.LogSqlInConsole = true;
            });

            config.AddAssembly(Assembly.GetExecutingAssembly());
            //config.Configure();
            return config;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();

                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}