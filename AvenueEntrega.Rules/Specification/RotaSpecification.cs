﻿using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules.Specification
{
    public static class RotaSpecification
    {
        public static void Validate(this Rota rota)
        {
            rota.ClearBrokenRules();

            if(string.IsNullOrEmpty(rota.Origem))
                rota.BrokenRules.Add("Origem","A rota precisa possuir uma origem");

            if(string.IsNullOrEmpty(rota.Destino))
                rota.BrokenRules.Add("Destino","A rota precisa possuir um destino");

            //TODO: declare more specifications if needed
        }
    }
}