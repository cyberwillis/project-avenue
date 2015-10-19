using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Services.ExtensionMethods
{
    public static class RotaExtensions
    {
        public static RotaDto ConvertToRotaDto( this Rota rota)
        {
            IFormatProvider culture = Thread.CurrentThread.CurrentCulture;

            var rotaDto = new RotaDto();
            rotaDto.Id = rota.Id.ToString();
            rotaDto.Origem = rota.Origem;
            rotaDto.Destino = rota.Destino;
            rotaDto.Custo = rota.Custo.ToString("n", culture);

            return rotaDto;
        }

        public static IList<RotaDto> ConvertToListRotasDto( this IList<Rota> rotas)
        {
            var rotasDto = rotas.Select(rota => rota.ConvertToRotaDto()).ToList();

            return rotasDto;
        }


        public static Rota ConvertToRota(this RotaDto rotaDto)
        {
            IFormatProvider culture = Thread.CurrentThread.CurrentCulture;

            var rota = new Rota();
            if(!string.IsNullOrEmpty(rotaDto.Id))
                rota.Id = Guid.Parse(rotaDto.Id);

            rota.Origem = rotaDto.Origem;
            rota.Destino = rotaDto.Destino;
            
            rota.Custo = decimal.Parse(rotaDto.Custo, culture);

            return rota;
        }

        public static IList<Rota> ConvertToListRotas(this IList<RotaDto> rotasDto)
        {
            var rotas = rotasDto.Select(rotaDto => rotaDto.ConvertToRota()).ToList();

            return rotas;
        }
    }
}