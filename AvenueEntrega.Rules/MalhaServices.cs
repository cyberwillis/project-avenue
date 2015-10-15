using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules
{
    public class MalhaServices
    {
        public float EncontrarMelhorRota(Mapa mapa, string origem, string destino, float autonomia)
        {
            if (mapa != null)
            {
                var malha = new Malha(mapa.Rotas);

                //TODO: calculo da melhor roda por A*
                //saber se origem esta no mapa
                //saber se destino esta no mapa
                //saber se existe um trajeto ate o destino
            }
            return 0.0f;
        }
    }
}
