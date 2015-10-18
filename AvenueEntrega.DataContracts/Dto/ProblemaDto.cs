using System.Runtime.Serialization;

namespace AvenueEntrega.DataContracts.Dto
{
    [DataContract(Name = "ProblemaDto", Namespace = "dto.avenueentrega.com")]
    public class ProblemaDto
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string NomeMapa { get; set; }

        [DataMember]
        public string Origem { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public string AutonomiaVeiculo { get; set; }

        [DataMember]
        public string ValorCombustivel { get; set; }
    }
}