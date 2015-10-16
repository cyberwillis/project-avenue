using AvenueEntrega.DataContracts.Dto;

namespace AvenueEntrega.DataContracts.Messages.Mapa
{
    public class EncontrarMapaPorResponse : ResponseBase
    {
         public MapaDto Mapa { get; set; }
    }
}