using System.Collections.Generic;

namespace AvenueEntrega.Model.Entities
{
    public class Malha
    {
        private IList<Rota> _rotas;
        //public Dictionary<string, IList<Rota>> Direcoes { get; protected set; }


        public Malha(IList<Rota> rotas)
        {
            this._rotas = rotas;

            //Direcoes = new Dictionary<string, IList<Rota>>();

            ////TODO: otimize , it exponential
            //foreach (var rota in rotas)
            //{
            //    //source to destiny test
            //    if (this.Direcoes.ContainsKey(rota.Origem))
            //        this.Direcoes[rota.Origem].Add(rota); //add/update
            //    else
            //        this.Direcoes.Add(rota.Origem, new List<Rota>() { rota }); //create

            //    //destination to source test
            //    if (this.Direcoes.ContainsKey(rota.Destino))
            //        this.Direcoes[rota.Destino].Add(rota); //add/update
            //    else
            //        this.Direcoes.Add(rota.Destino, new List<Rota>() { rota }); //create
            //}
        }

        public IList<Rota> PossibleActions(string ponto)
        {
            var possibilidades = new List<Rota>();

            foreach (var rota in _rotas)
            {
                if (rota.Origem.Equals(ponto) || rota.Destino.Equals(ponto))
                    possibilidades.Add(rota);
            }

            return possibilidades;
        }
    }
}