using System.Collections.Generic;
using System.ServiceModel;

namespace AvenueEntrega.DataContracts.Messages.Problema
{
    [MessageContract(WrapperNamespace = "messages.avenueentrega.com")]
    public class CalcularMelhorRotaResponse : ResponseBase
    {
        [MessageBodyMember]
        public string CustoTotal { get; set; }

        [MessageBodyMember]
        public IList<string> MelhorCaminho { get; set; }
    }
}