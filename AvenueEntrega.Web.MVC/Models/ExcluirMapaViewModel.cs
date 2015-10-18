using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AvenueEntrega.I18N;

namespace AvenueEntrega.Web.MVC.Models
{
    public class ExcluirMapaViewModel
    {
        public string Id { get; set; }

        [Display(Name = "ExcluirMapaViewModel_AttributeName_NomeMapa", ResourceType = typeof(Resources))]
        public string NomeMapa { get; set; }
    }
}