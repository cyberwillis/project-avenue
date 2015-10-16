using System.Collections.Generic;

namespace AvenueEntrega.DataContracts.Messages.Problema
{
    public class CalcularMelhorRotaResponse : ResponseBase
    {
        public string CustoTotal { get; set; }
        public IList<string> MelhorCaminho { get; set; }
    }
}