using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules.Specification
{
    public static class MapaSpecification
    {
        public static void Validate(this Mapa mapa)
        {
            mapa.ClearBrokenRules();

            if (string.IsNullOrEmpty(mapa.NomeMapa))
                mapa.BrokenRules.Add("Nome","O nome do mapa precisa ser especificado.");

            if(mapa.Rotas.Count == 0)
                mapa.BrokenRules.Add("Rotas", "O mapa precisa possuir rotas.");

            //TODO: declare more specifications if needed
        }
    }
}