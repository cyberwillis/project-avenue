using System;
using System.ServiceModel;
using System.Web.UI;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;
using AvenueEntrega.RepositoryNHibernate;
using AvenueEntrega.RepositoryNHibernate.Repositories;
using AvenueEntrega.ServiceContracts;
using AvenueEntrega.Services;
using AvenueEntrega.Web.WCF.IoC;
using Microsoft.Practices.Unity;

namespace AvenueEntrega.Web.WCF
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        public ServiceHost GetInstance(Type serviceType, params Uri[] baseAddresses)
        {
            return base.CreateServiceHost(serviceType, baseAddresses);
        }

        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            // container
            //    .RegisterType<IService1, Service1>()
            //    .RegisterType<DataContext>(new HierarchicalLifetimeManager());

            container
                .RegisterType<IMapaService,MapaServices>()
                .RegisterType<IMapaRepository, MapaRepository>()
                .RegisterType<IUnitOfWork<Mapa>, NHUnitOfWork<Mapa>>()
                .RegisterType<IUnitOfWorkRepository<Mapa>,NHUnitOfWorkRepository<Mapa>>();
        }
    }
}