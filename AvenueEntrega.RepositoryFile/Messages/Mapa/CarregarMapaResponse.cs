using AvenueEntrega.RepositoryFile.Dto;

namespace AvenueEntrega.RepositoryFile.Messages.Mapa
{
    public class CarregarMapaResponse : ResponseBase
    {
         public MapaRepositoryDto Mapa { get; set; }
    }
}