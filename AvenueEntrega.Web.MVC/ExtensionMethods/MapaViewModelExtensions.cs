using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.Web.MVC.Models;

namespace AvenueEntrega.Web.MVC.ExtensionMethods
{
    public static class MapaViewModelExtensions
    {
        public static MapaViewModel ConvertToMapaViewModel(this MapaDto mapaDto)
        {
            var mapaView = new MapaViewModel();
            mapaView.Id = mapaDto.Id;
            mapaView.NomeMapa = mapaDto.NomeMapa;

            return mapaView;
        }

        public static IList<MapaViewModel> ConvertToListMapaViewModel(this IList<MapaDto> mapasDto)
        {
            var mapasView = mapasDto.Select(mapaDto => mapaDto.ConvertToMapaViewModel()).ToList();

            return mapasView;
        }

        public static MapaDto ConvertToMapaDto(this MapaViewModel mapaView)
        {
            var mapaDto = new MapaDto();
            mapaDto.Id = mapaView.Id;
            mapaDto.NomeMapa = mapaView.NomeMapa;

            return mapaDto;
        }

        public static IList<MapaDto> ConvertToMapasDto(this IList<MapaViewModel> mapasView)
        {
            var mapasDto = mapasView.Select(mapaViewModel => mapaViewModel.ConvertToMapaDto()).ToList();

            return mapasDto;
        }
    }
}