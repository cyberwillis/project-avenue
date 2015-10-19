using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AvenueEntrega.DataContracts.Dto;

namespace AvenueEntrega.DataContracts.Messages.Mapa
{
    [MessageContract(WrapperNamespace = "messages.avenueentrega.com")]
    public class EncontrarTodosMapasPorRequest
    {
        [MessageBodyMember]
        public MapaDto Mapa { get; set; }
    }
}
