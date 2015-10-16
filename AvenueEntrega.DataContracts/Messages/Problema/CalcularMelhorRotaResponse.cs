namespace AvenueEntrega.DataContracts.Messages.Problema
{
    public class CalcularMelhorRotaResponse : ResponseBase
    {
        public string CustoTotal { get; set; }
        public string MelhorCaminho { get; set; }
    }
}