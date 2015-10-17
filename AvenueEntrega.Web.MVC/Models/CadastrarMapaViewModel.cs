using System.ComponentModel.DataAnnotations;

namespace AvenueEntrega.Web.MVC.Models
{
    public class CadastrarMapaViewModel
    {
        [Display(Name = "Nome do mapa")]
        public string NomeMapa { get; set; }

        [Display(Name = "Arquivo de carga")]
        public string File { get; set; }
    }
}