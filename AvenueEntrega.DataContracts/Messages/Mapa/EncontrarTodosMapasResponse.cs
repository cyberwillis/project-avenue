using System.Collections.Generic;
using System.ServiceModel;
using AvenueEntrega.DataContracts.Dto;

namespace AvenueEntrega.DataContracts.Messages.Mapa
{
    [MessageContract(WrapperNamespace = "messages.avenueentrega.com")]
    public class EncontrarTodosMapasResponse : ResponseBase
    {
        [MessageBodyMember]
        public IList<MapaDto> Mapas { get; set; }
    }
}