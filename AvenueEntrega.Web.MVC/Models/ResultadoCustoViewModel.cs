using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvenueEntrega.Web.MVC.Models
{
    public class ResultadoCustoViewModel
    {
        public string Id { get; set; }
        public string NomeMapa { get; set; }

        
        [Display(Name = "Caminho")]
        public string Caminho { get; set; }

        [Display(Name = "Custo Total")]
        public string CustoTotal { get; set; }

        

    }
}