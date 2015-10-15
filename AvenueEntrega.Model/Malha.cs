using System.Collections.Generic;

namespace AvenueEntrega.Model
{
    public class Malha
    {
        IList<Dictionary<string, IList<Rota>>> Direcoes { get; set; }

        public Malha()
        {
            Direcoes = new List<Dictionary<string, IList<Rota>>>();
        }
    }
}