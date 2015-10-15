using System.Collections.Generic;

namespace AvenueEntrega.Model
{
    public class Mapa
    {
        public string NomeMapa { get; set; }
        public IList<Rota> Rotas { get; set; }
    }
}
