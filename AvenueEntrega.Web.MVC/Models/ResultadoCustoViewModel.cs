using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AvenueEntrega.I18N;

namespace AvenueEntrega.Web.MVC.Models
{
    public class ResultadoCustoViewModel
    {
        public string Id { get; set; }
        public string NomeMapa { get; set; }

        [Display(Name = "ResultadoCustoViewModel_AttributeName_Caminho", ResourceType = typeof(Resources))]
        public string Caminho { get; set; }

        [Display(Name = "ResultadoCustoViewModel_AttributeName_CustoTotal", ResourceType = typeof(Resources))]
        public string CustoTotal { get; set; }
    }
}