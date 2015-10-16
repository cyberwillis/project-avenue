namespace AvenueEntrega.Model.Entities
{
    public class Problema : ModelBase
    {
        public string NomeMapa { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public float AutonomiaVeiculo { get; set; }
        public float ValorCombustivel { get; set; }
    }
}