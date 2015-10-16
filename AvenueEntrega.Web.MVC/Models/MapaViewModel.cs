using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AvenueEntrega.Web.MVC.Models
{
    public class MapaViewModel
    {
        [Display(Name = "Codigo")]
        public string Id { get; set; }
        [Display(Name = "Nome do Mapa")]
        public string NomeMapa { get; set; }
        [Display(Name = "Arquivo para carga (.txt)")]
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