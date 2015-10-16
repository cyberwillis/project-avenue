using System.Collections.Generic;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.Web.MVC.Models;

namespace AvenueEntrega.Web.MVC.ExtensionMethods
{
    public static class RotaViewModelExtensions
    {
        //public static RotaDestinoViewModel ConvertToRotaDestinoViewModel(this RotaDto rotaDto)
        //{
        //    var rotaDestino = new RotaDestinoViewModel();
        //    rotaDestino.Destino = rotaDto.Destino;

        //    return rotaDestino;
        //}

        public static IList<RotaDestinoViewModel> ConvertToListRotaDestinoViewMode(this IList<RotaDto> rotasDto)
        {
            var rotasDestino = new List<RotaDestinoViewModel>();

            var dict = new Dictionary<string, string>();
            foreach (var rotaDto in rotasDto)
            {
                if(!dict.ContainsKey(rotaDto.Destino))
                    dict.Add(rotaDto.Destino, "");
            }

            foreach (var item in dict)
            {
                rotasDestino.Add(new RotaDestinoViewModel() {Destino = item.Key});
            }

            return rotasDestino;
        }

        public static IList<RotaOrigemViewModel> ConvertToListRotaOrigemViewMode(this IList<RotaDto> rotasDto)
        {
            var rotasOrigem = new List<RotaOrigemViewModel>();

            var dict = new Dictionary<string, string>();
            foreach (var rotaDto in rotasDto)
            {
                if (!dict.ContainsKey(rotaDto.Origem))
                    dict.Add(rotaDto.Origem, "");
            }

            foreach (var item in dict)
            {
                rotasOrigem.Add(new RotaOrigemViewModel() { Origem = item.Key });
            }

            return rotasOrigem;
        }
    }
}