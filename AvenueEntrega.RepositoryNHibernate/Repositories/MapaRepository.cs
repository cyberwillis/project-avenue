using System;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryNHibernate.Repositories
{
    public class MapaRepository : RepositoryBase<Mapa,Guid>, IMapaRepository
    {
        public MapaRepository(IUnitOfWork<Mapa> unitOfWork) : base(unitOfWork)
        {
        }

        public Mapa FindByName(string name)
        {
            var mapa = from m in SessionFactory.GetCurrentSession().QueryOver<Mapa>()
                where m.NomeMapa == name
                select m;

            return mapa.SingleOrDefault();
        }
    }
}