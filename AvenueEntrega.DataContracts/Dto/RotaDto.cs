using System.Runtime.Serialization;

namespace AvenueEntrega.DataContracts.Dto
{
    [DataContract(Name = "RotaDto", Namespace = "dto.avenueentrega.com")]
    public class RotaDto
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Origem { get; set; }

        [DataMember]
        public string Destino { get; set; }

        [DataMember]
        public string Custo { get; set; }
    }
}