using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.Model.Repository;
using AvenueEntrega.ServiceContracts;

namespace AvenueEntrega.Services
{
    public class MapaServices : IMapaService
    {
        private readonly IMapaRepository _mapaRepository;

        public MapaServices(IMapaRepository mapaRepository)
        {
            _mapaRepository = mapaRepository;
        }


        public EncontrarTodosMapasResponse EncontrarTodosMapas()
        {
            throw new System.NotImplementedException();
        }

        public ExcluirMapaResponse ExcluirMapa(ExcluirMapaRequest request)
        {
            throw new System.NotImplementedException();
        }

        public AlterarMapaResponse AlterarMapa(AlterarMapaRequest request)
        {
            throw new System.NotImplementedException();
        }

        public InserirMapaResponse InserirMapa(InserirMapaRequest request)
        {
            throw new System.NotImplementedException();
        }

        public EncontrarMapaPorResponse EncontrarMapaPor(EncontrarMapaPorRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
