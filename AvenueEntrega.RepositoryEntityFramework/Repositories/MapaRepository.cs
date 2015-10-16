using System;
using System.Linq;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryEntityFramework.Repositories
{
    public class MapaRepository : RepositoryBase<Mapa, Guid, MapaContext>
    {
        public MapaRepository(IUnitOfWork<Mapa> unitOfWork) : base(unitOfWork)
        {
        }

        public Mapa FindByName(string name)
        {
            var mapa = from m in DataContextFactory<MapaContext>.GetDataContext().Mapas
                where m.NomeMapa == name
                select m;

            return mapa.SingleOrDefault();
        }
    }
}