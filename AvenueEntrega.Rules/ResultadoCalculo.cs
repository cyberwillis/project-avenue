using System.Collections.Generic;

namespace AvenueEntrega.Rules
{
    public class ResultadoCalculo
    {
        public float CustoTotal { get; set; }
        public IList<string> MelhorCaminho { get; set; }

        public ResultadoCalculo()
        {
            MelhorCaminho = new List<string>();
        }
    }
}