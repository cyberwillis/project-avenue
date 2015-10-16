using System;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.RepositoryEntityFramework.Repositories
{
    public class MapaRepository : RepositoryBase<Mapa, Guid, MapaContext>
    {
        public MapaRepository(IUnitOfWork<Mapa> unitOfWork) : base(unitOfWork)
        {
        }
    }
}