using System.Collections.Generic;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Model
{
    public class Malha
    {
        public Dictionary<string, IList<Rota>> Direcoes { get; protected set; }

        public Malha( IList<Rota> rotas )
        {
            Direcoes = new Dictionary<string, IList<Rota>>();

            foreach (var rota in rotas)
            {
                if (this.Direcoes.ContainsKey(rota.Origem))
                {
                    //add/update
                    this.Direcoes[rota.Origem].Add(rota);
                }
                else
                {
                    //create
                    this.Direcoes.Add(rota.Origem, new List<Rota>() { rota });
                }
            }
        }
    }
}