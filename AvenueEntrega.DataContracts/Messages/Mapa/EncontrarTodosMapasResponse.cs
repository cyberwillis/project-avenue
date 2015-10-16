using System.Collections.Generic;
using AvenueEntrega.DataContracts.Dto;

namespace AvenueEntrega.DataContracts.Messages.Mapa
{
    public class EncontrarTodosMapasResponse : ResponseBase
    {
         public IList<MapaDto> Mapas { get; set; }
    }
}