using System.ServiceModel;
using AvenueEntrega.DataContracts.Dto;

namespace AvenueEntrega.DataContracts.Messages.Mapa
{
    [MessageContract(WrapperNamespace = "messages.avenueentrega.com")]
    public class EncontrarMapaPorRequest
    {
        [MessageBodyMember]
        public MapaDto Mapa { get; set; } 
    }
}