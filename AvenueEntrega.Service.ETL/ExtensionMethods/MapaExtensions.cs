using System;
using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.RepositoryFile.Dto;

namespace AvenueEntrega.Service.ETL.ExtensionMethods
{
    public static class MapaExtensions
    {
        public static MapaRepositoryDto ConvertoToMapaRepositoryDto( this Mapa mapa)
        {
            var mapaDto = new MapaRepositoryDto();
            //mapaDto.Id = mapa.Id.ToString();
            mapaDto.NomeMapa = mapa.NomeMapa;

            if (mapa.Rotas.Count > 0)
                mapaDto.Rotas = mapa.Rotas.ConvertToListRotasDto();

            return mapaDto;
        }

        public static IList<MapaRepositoryDto> ConvertToListMapasDto(this IList<Mapa> mapas)
        {
            var mapasDto = mapas.Select(mapa => mapa.ConvertoToMapaRepositoryDto()).ToList();

            return mapasDto;
        }

        public static Mapa ConvertToMapa(this MapaRepositoryDto mapaRepositoryDto)
        {
            var mapa = new Mapa();
            //if(!string.IsNullOrEmpty(mapaDto.Id))
            //    mapa.Id = Guid.Parse(mapaDto.Id);

            mapa.NomeMapa = mapaRepositoryDto.NomeMapa;

            if (mapaRepositoryDto.Rotas.Count > 0)
                mapa.Rotas = mapaRepositoryDto.Rotas.ConvertToListRotas();

            return mapa;
        }

        public static IList<Mapa> ConvertToListMapas(this IList<MapaRepositoryDto> mapasRepositoryDto)
        {
            var mapas = mapasRepositoryDto.Select(mapaDto => mapaDto.ConvertToMapa()).ToList();

            return mapas;
        }

    }
}