using System;
using AvenueEntrega.I18N;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules.Specification
{
    public static class ProblemaSpecification
    {
        public static void Validate(this Problema problema)
        {
            problema.ClearBrokenRules();

            if(string.IsNullOrEmpty(problema.NomeMapa) && string.IsNullOrEmpty(problema.Id))
                problema.BrokenRules.Add("NomeMapa", Resources.ProblemSpecification_AttributeName_NomeMapa);//Um mapa deve ser especificado.

            if (string.IsNullOrEmpty(problema.Origem))
                problema.BrokenRules.Add("Origem" ,Resources.ProblemSpecification_AttributeName_Origem);//A origem deve ser especificada.

            if (string.IsNullOrEmpty(problema.Destino))
                problema.BrokenRules.Add("Destino", Resources.ProblemSpecification_AttributeName_Destino);//O destino deve ser especificado.

            if (problema.AutonomiaVeiculo == 0.00m)
                problema.BrokenRules.Add("AutonomiaVeiculo", Resources.ProblemSpecification_AttributeName_AutonomiaVeiculo);//A autonomia do veículo não pode ser zero.

            if (problema.ValorCombustivel == 0.00m)
                problema.BrokenRules.Add("ValorCombustivel", Resources.ProblemSpecification_AttributeName_ValorCombustivel);//O valor do combustivel não pode ser zero.

            //TODO: declare more specifications if needed
        }
    }
}