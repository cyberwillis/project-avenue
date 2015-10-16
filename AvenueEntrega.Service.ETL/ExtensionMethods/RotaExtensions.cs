using System;
using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.RepositoryFile.Dto;

namespace AvenueEntrega.Service.ETL.ExtensionMethods
{
    public static class RotaExtensions
    {
        public static RotaRepositoryDto ConvertToRotaDto( this Rota rota)
        {
            var rotaDto = new RotaRepositoryDto();
            //rotaDto.Id = rota.Id.ToString();
            rotaDto.Origem = rota.Origem;
            rotaDto.Destino = rota.Destino;
            rotaDto.Custo = rota.Custo;

            return rotaDto;
        }

        public static IList<RotaRepositoryDto> ConvertToListRotasDto( this IList<Rota> rotas)
        {
            var rotasDto = rotas.Select(rota => rota.ConvertToRotaDto()).ToList();

            return rotasDto;
        }


        public static Rota ConvertToRota(this RotaRepositoryDto rotaDto)
        {
            var rota = new Rota();
            //if(!string.IsNullOrEmpty(rotaDto.Id))

            rota.Id = Guid.NewGuid();
            rota.Origem = rotaDto.Origem;
            rota.Destino = rotaDto.Destino;
            rota.Custo = rotaDto.Custo;

            return rota;
        }

        public static IList<Rota> ConvertToListRotas(this IList<RotaRepositoryDto> rotasDto)
        {
            var rotas = rotasDto.Select(rotaDto => rotaDto.ConvertToRota()).ToList();

            return rotas;
        }
    }
}