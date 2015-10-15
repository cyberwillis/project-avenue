using System.Collections.Generic;

namespace AvenueEntrega.Model.Entities
{
    public class Malha
    {
        public Malha(IList<Rota> rotas)
        {
            var malha = new Dictionary<string, IList<Rota>>();

            foreach (var rota in rotas)
            {
                if (malha.ContainsKey(rota.Origem))
                {
                    //add/update
                    malha[rota.Origem].Add(rota);
                }
                else
                {
                    //create
                    malha.Add(rota.Origem, new List<Rota>() { rota });
                }
            }
        }
    }
}