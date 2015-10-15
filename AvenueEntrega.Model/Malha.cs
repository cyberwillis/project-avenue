using System.Collections.Generic;

namespace AvenueEntrega.Model
{
    public class Malha
    {
        public Dictionary<string, IList<Rota>> Direcoes { get; set; }

        public Malha()
        {
            Direcoes = new Dictionary<string, IList<Rota>>();
        }
    }
}