using System.Collections.Generic;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules.UnitTest.Extensions
{
    public static class MapaExtensions
    {
        public static IList<string> PossibleActions(this Mapa mapa, string ponto)
        {
            var actions = new List<string>();

            foreach (var rota in mapa.Rotas)
            {
                if (rota.Origem.Equals(ponto))
                    actions.Add(rota.Destino);

                if (rota.Destino.Equals(ponto))
                    actions.Add(rota.Origem);
            }

            return actions;
        }
    }
}