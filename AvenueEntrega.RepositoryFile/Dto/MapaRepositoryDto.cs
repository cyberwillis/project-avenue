using System.Collections.Generic;
using FileHelpers;

namespace AvenueEntrega.RepositoryFile.Dto
{
    public class MapaRepositoryDto
    {
        public string NomeMapa { get; set; }
        public IList<RotaRepositoryDto> Rotas { get; set; }
    }
}