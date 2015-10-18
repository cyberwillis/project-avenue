using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AvenueEntrega.DataContracts.Dto
{
    [DataContract(Name = "MapaDto", Namespace = "dto.avenueentrega.com")]
    public class MapaDto
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string NomeMapa { get; set; }

        [DataMember]
        public IList<RotaDto> Rotas { get; set; }

        public MapaDto()
        {
            Rotas = new List<RotaDto>();
        }
    }
}