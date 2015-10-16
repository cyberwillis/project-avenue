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

            if(Math.Abs(problema.AutonomiaVeiculo)< 0.001)
                problema.BrokenRules.Add("AutonomiaVeiculo","A autonomia do veículo nao pode ser zero.");

            if(Math.Abs(problema.ValorCombustivel) < 0.001)
                problema.BrokenRules.Add("ValorCombustivel", "O valod do combustivel nao pode ser zero.");

            //TODO: declare more specifications if needed
        }
    }
}