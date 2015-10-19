using System;
using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;
using NHibernate.Linq;

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

        public IList<Mapa> FindAllByName(string name)
        {
            var mapas = SessionFactory.GetCurrentSession()
                .Query<Mapa>()
                .Where(x => x.NomeMapa
                .Contains(name));

            return mapas.ToList();
        }
    }
}