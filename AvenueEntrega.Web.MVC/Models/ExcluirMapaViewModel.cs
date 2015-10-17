using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AvenueEntrega.Web.MVC.Models
{
    public class ExcluirMapaViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Nome do Mapa:")]
        public string NomeMapa { get; set; }
    }
}