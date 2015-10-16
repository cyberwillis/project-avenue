using AvenueEntrega.DataContracts.Messages.Mapa;

namespace AvenueEntrega.ServiceContracts
{
    public interface IMapaService
    {
        EncontrarTodosMapasResponse EncontrarTodosMapas();
        EncontrarMapaPorResponse EncontrarMapaPor(EncontrarMapaPorRequest request);
        InserirMapaResponse InserirMapa(InserirMapaRequest request);
        AlterarMapaResponse AlterarMapa(AlterarMapaRequest request);
        ExcluirMapaResponse ExcluirMapa(ExcluirMapaRequest request);
    }
}