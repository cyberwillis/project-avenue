using System.ServiceModel;
using AvenueEntrega.DataContracts.Dto;

namespace AvenueEntrega.DataContracts.Messages.Problema
{
    [MessageContract(WrapperNamespace = "messages.avenueentrega.com")]
    public class CalcularMelhorRotaRequest
    {
        [MessageBodyMember]
        public ProblemaDto Problema { get; set; }
    }
}