using AvenueEntrega.Model.Entities;
using AvenueEntrega.Rules.Specification;

namespace AvenueEntrega.Rules
{
    public static class ProblemaService
    {
        public static bool IsValid(this Problema problema)
        {
            ProblemaSpecification.Validate(problema);

            return (problema.BrokenRules.Count == 0);
        }
    }
}