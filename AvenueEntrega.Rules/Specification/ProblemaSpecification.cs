using System;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules.Specification
{
    public static class ProblemaSpecification
    {
        public static void Validate(this Problema problema)
        {
            problema.ClearBrokenRules();

            if(string.IsNullOrEmpty(problema.NomeMapa))
                problema.BrokenRules.Add("NomeMapa", "Um mapa deve ser especificado.");

            if(string.IsNullOrEmpty(problema.Origem))
                problema.BrokenRules.Add("Origem" ,"A origem deve ser especificada.");

            if(string.IsNullOrEmpty(problema.Destino))
                problema.BrokenRules.Add("Destino", "O destino deve ser especificado.");

            if(Math.Abs(problema.AutonomiaVeiculo)< 0.01)
                problema.BrokenRules.Add("AutonomiaVeiculo","O veículo deve possuir uma autonomia.");

            if(Math.Abs(problema.ValorCombustivel) < 0.001)
                problema.BrokenRules.Add("ValorCombustivel", "O combustível deve possuir um custo.");

            //TODO: declare more specifications if needed
        }
    }
}