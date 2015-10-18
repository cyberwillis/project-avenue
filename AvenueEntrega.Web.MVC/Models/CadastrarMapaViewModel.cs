using System.ComponentModel.DataAnnotations;
using AvenueEntrega.I18N;

namespace AvenueEntrega.Web.MVC.Models
{
    public class CadastrarMapaViewModel
    {
        [Display(Name = "CadastrarMapaViewModel_AttributeName_NomeMapa", ResourceType = typeof(Resources))]
        public string NomeMapa { get; set; }

        [Display(Name = "CadastrarMapaViewModel_AttributeName_File", ResourceType = typeof(Resources))]
        public string File { get; set; }
    }
}