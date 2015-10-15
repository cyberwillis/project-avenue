using System;
using System.Collections.Generic;

namespace AvenueEntrega.Model.Entities
{
    public class Mapa : ModelBase, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string NomeMapa { get; set; }
        public IList<Rota> Rotas { get; set; }
    }
}
