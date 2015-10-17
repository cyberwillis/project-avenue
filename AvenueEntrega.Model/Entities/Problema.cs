namespace AvenueEntrega.Model.Entities
{
    public class Problema : ModelBase
    {
        public string Id { get; set; }
        public string NomeMapa { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal AutonomiaVeiculo { get; set; }
        public decimal ValorCombustivel { get; set; }
    }
}