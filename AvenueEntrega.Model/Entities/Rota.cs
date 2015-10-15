using System;

namespace AvenueEntrega.Model.Entities
{
    public class Rota : ModelBase, IEntityBase<Guid>
    {
        public Guid Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public float Custo { get; set; }
    }
}