using System;
using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Services.ExtensionMethods
{
    public static class MapaExtensions
    {
        public static MapaDto ConvertoToMapaDto( this Mapa mapa)
        {
            var mapaDto = new MapaDto();
            mapaDto.Id = mapa.Id.ToString();
            mapaDto.NomeMapa = mapa.NomeMapa;

            if (mapa.Rotas.Count > 0)
                mapaDto.Rotas = mapa.Rotas.ConvertToListRotasDto();

            return mapaDto;
        }

        public static IList<MapaDto> ConvertToListMapasDto(this IList<Mapa> mapas)
        {
            var mapasDto = mapas.Select(mapa => mapa.ConvertoToMapaDto()).ToList();

            return mapasDto;
        }

        public static Mapa ConvertToMapa(this MapaDto mapaDto)
        {
            var mapa = new Mapa();
            if(!string.IsNullOrEmpty(mapaDto.Id))
                mapa.Id = Guid.Parse(mapaDto.Id);

            mapa.NomeMapa = mapaDto.NomeMapa;

            if (mapaDto.Rotas.Count > 0)
                mapa.Rotas = mapaDto.Rotas.ConvertToListRotas();

            return mapa;
        }

        public static IList<Mapa> ConvertToListMapas(this IList<MapaDto> mapasDto)
        {
            var mapas = mapasDto.Select(mapaDto => mapaDto.ConvertToMapa()).ToList();

            return mapas;
        }

    }
}