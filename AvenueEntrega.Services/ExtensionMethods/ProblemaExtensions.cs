using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Services.ExtensionMethods
{
    public static class ProblemaExtensions
    {
        public static ProblemaDto ConvertToProblemaDto(this Problema problema)
        {
            var problemaDto = new ProblemaDto();
            problemaDto.NomeMapa = problema.NomeMapa;
            problemaDto.Origem = problema.Origem;
            problemaDto.Destino = problema.Destino;
            problemaDto.AutonomiaVeiculo = problema.AutonomiaVeiculo.ToString();
            problemaDto.ValorCombustivel = problema.ValorCombustivel.ToString();

            return problemaDto;
        }

        public static IList<ProblemaDto> ConvertToListProblemaDto(this IList<Problema> problemas)
        {
            var problemasDto = problemas.Select(problema => problema.ConvertToProblemaDto()).ToList();

            return problemasDto;
        }

        public static Problema ConvertToProblema(this ProblemaDto problemaDto)
        {
            var problema = new Problema();
            problema.NomeMapa = problemaDto.NomeMapa;
            problema.Origem = problemaDto.Origem;
            problema.Destino = problemaDto.Destino;
            problema.AutonomiaVeiculo = float.Parse(problemaDto.AutonomiaVeiculo);
            problema.ValorCombustivel = float.Parse(problemaDto.ValorCombustivel);

            return problema;
        }

        public static IList<Problema> ConvertToListProblema(this IList<ProblemaDto> problemasDto)
        {
            var problemas = problemasDto.Select(problemaDto => problemaDto.ConvertToProblema()).ToList();

            return problemas;
        }
    }
}