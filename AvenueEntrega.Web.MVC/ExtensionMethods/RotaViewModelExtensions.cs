using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.Web.MVC.Models;

namespace AvenueEntrega.Web.MVC.ExtensionMethods
{
    public static class RotaViewModelExtensions
    {
        public static IList<RotaDestinoViewModel> ConvertToListRotaDestinoViewMode(this IList<RotaDto> rotasDto)
        {
            var dict = new Dictionary<string, string>();
            foreach (var rotaDto in rotasDto)
            {
                if(!dict.ContainsKey(rotaDto.Destino))
                    dict.Add(rotaDto.Destino, string.Empty);
            }

            var rotasDestino = dict.Select(item => new RotaDestinoViewModel() {Destino = item.Key}).ToList();

            var sortedDestino = rotasDestino.OrderBy(o => o.Destino).ToList();

            return sortedDestino;
        }

        public static IList<RotaOrigemViewModel> ConvertToListRotaOrigemViewMode(this IList<RotaDto> rotasDto)
        {
            var dict = new Dictionary<string, string>();

            foreach (var rotaDto in rotasDto)
            {
                if (!dict.ContainsKey(rotaDto.Origem))
                    dict.Add(rotaDto.Origem, string.Empty);
            }

            var rotasOrigem = dict.Select(item => new RotaOrigemViewModel() {Origem = item.Key}).ToList();

            var sortedOrigem = rotasOrigem.OrderBy(o => o.Origem).ToList();

            return sortedOrigem;
        }
    }
}