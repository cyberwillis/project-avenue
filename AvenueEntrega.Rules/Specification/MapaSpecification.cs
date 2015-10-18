using AvenueEntrega.I18N;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules.Specification
{
    public static class MapaSpecification
    {
        public static void Validate(this Mapa mapa)
        {
            mapa.ClearBrokenRules();

            if (string.IsNullOrEmpty(mapa.NomeMapa))
                mapa.BrokenRules.Add("Nome",Resources.MapaSpecification_AttributeName_NomeMapa);//O nome do mapa precisa ser especificado.

            if (mapa.Rotas.Count == 0)
                mapa.BrokenRules.Add("Rotas", Resources.MapaSpecification_AttributeName_Rotas);//"O mapa precisa possuir rotas."

            //TODO: declare more specifications if needed
        }
    }
}