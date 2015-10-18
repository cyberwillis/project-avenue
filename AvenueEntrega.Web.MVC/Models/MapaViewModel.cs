using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AvenueEntrega.I18N;

namespace AvenueEntrega.Web.MVC.Models
{
    public class MapaViewModel
    {
        [Display(Name = "MapaViewModel_AttributeName_Id", ResourceType = typeof(Resources))]
        public string Id { get; set; }
        [Display(Name = "MapaViewModel_AttributeName_NomeMapa", ResourceType = typeof(Resources))]
        public string NomeMapa { get; set; }
        [Display(Name = "MapaViewModel_AttributeName_Arquivo", ResourceType = typeof(Resources))]
        public string Arquivo { get; set; }
        //public IList<ListaMapaViewModel> Mapas { get; set; }

        //public SelectList GetMapasSelectList()
        //{
        //    var list = new List<ListaMapaViewModel>();
        //    list.Add(new ListaMapaViewModel() {Id="", Nome ="Selecione" });

        //    if (Mapas != null)
        //    {
        //        list.AddRange(Mapas);
        //    }
        //    return new SelectList(list,"Id","Nome");
        //}
    }
}