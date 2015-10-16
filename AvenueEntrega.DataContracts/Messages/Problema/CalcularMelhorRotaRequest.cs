namespace AvenueEntrega.DataContracts.Messages.Problema
{
    public class CalcularMelhorRotaRequest
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string Autonomia { get; set; }
        public string ValorCombustivel { get; set; }
    }
}