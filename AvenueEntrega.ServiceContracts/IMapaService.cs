using System.ServiceModel;
using System.ServiceModel.Web;
using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.DataContracts.Messages.Problema;

namespace AvenueEntrega.ServiceContracts
{
    /// <summary>
    /// Interface and package compatibility with JAVA
    /// Operations in Json to connect mobile applications easly
    /// </summary>
    [ServiceContract(Namespace = "services.avenueentrega.com", Name = "MapaService")] 
    public interface IMapaService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        CalcularMelhorRotaResponse CalcularRota(CalcularMelhorRotaRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EncontrarTodosMapasResponse EncontrarTodosMapas();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        EncontrarMapaPorResponse EncontrarMapaPor(EncontrarMapaPorRequest request);

        InserirMapaResponse InserirMapa(InserirMapaRequest request);

        AlterarMapaResponse AlterarMapa(AlterarMapaRequest request);

        ExcluirMapaResponse ExcluirMapa(ExcluirMapaRequest request);
    }
}