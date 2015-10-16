using System.Collections.Generic;

namespace AvenueEntrega.DataContracts.Dto
{
    public class MapaDto
    {
        public string NomeMapa { get; set; }
        public IList<RotaDto> Rotas { get; set; }
    }
}