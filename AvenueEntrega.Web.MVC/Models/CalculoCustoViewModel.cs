using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AvenueEntrega.I18N;

namespace AvenueEntrega.Web.MVC.Models
{
    public class CalculoCustoViewModel
    {
        public string Id { get; set; }
        [Display(Name = "CalculoCustoViewModel_AttributeName_NomeMapa", ResourceType = typeof(Resources))]
        public string NomeMapa { get; set; }

        [Display(Name = "CalculoCustoViewModel_AttributeName_Origem", ResourceType = typeof(Resources))]
        public string Origem { get; set; }

        [Display(Name = "CalculoCustoViewModel_AttributeName_Destino", ResourceType = typeof(Resources))]
        public string Destino { get; set; }

        [Display(Name = "CalculoCustoViewModel_AttributeName_Autonomia", ResourceType = typeof(Resources))]
        public string AutonomiaVeiculo { get; set; }

        [Display(Name = "CalculoCustoViewModel_AttributeName_ValorCombustivel", ResourceType = typeof(Resources))]
        public string ValorCombustivel { get; set; }

        public IList<RotaOrigemViewModel> Origens { get; set; }

        public IList<RotaDestinoViewModel> Destinos { get; set; }

        #region Helper Methods
        public SelectList GetOrigensSelectList()
        {
            var list = new List<RotaOrigemViewModel>();
            list.Add( new RotaOrigemViewModel() {Origem = "Selecione"});

            if (Origens != null)
            {
                list.AddRange(Origens);
            }

            return new SelectList(list, "Origem", "Origem");
        }

        public SelectList GetDestinosSelectList()
        {
            var list = new List<RotaDestinoViewModel>();
            list.Add(new RotaDestinoViewModel() { Destino = "Selecione"});

            if (Destinos != null)
            {
                list.AddRange(Destinos);
            }

            return new SelectList(list, "Destino", "Destino");
        }
        #endregion
    }
}