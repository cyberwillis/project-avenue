using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.DataContracts.Messages.Problema;

namespace AvenueEntrega.ServiceContracts
{
    public interface IMapaService
    {
        EncontrarTodosMapasResponse EncontrarTodosMapas();
        EncontrarMapaPorResponse EncontrarMapaPor(EncontrarMapaPorRequest request);
        InserirMapaResponse InserirMapa(InserirMapaRequest request);
        AlterarMapaResponse AlterarMapa(AlterarMapaRequest request);
        ExcluirMapaResponse ExcluirMapa(ExcluirMapaRequest request);
        CalcularMelhorRotaResponse CalcularRota(CalcularMelhorRotaRequest request);
    }
}