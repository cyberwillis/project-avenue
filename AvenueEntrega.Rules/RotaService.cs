using AvenueEntrega.Model.Entities;
using AvenueEntrega.Rules.Specification;

namespace AvenueEntrega.Rules
{
    public static class RotaService
    {
        public static bool IsValid(this Rota rota)
        {
            RotaSpecification.Validate(rota);

            return (rota.BrokenRules.Count == 0);
        }
    }
}