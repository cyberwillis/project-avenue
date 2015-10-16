using AvenueEntrega.Model.Entities;
using AvenueEntrega.Rules.Specification;

namespace AvenueEntrega.Rules
{
    public static class MapaService
    {
        public static bool IsValid(this Mapa mapa)
        {
            MapaSpecification.Validate(mapa);

            return (mapa.BrokenRules.Count == 0);
        }
    }
}