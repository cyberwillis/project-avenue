using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AvenueEntrega.Web.MVC.Models
{
    public class CalculoCustoViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Nome do Mapa")]
        public string NomeMapa { get; set; }

        [Display(Name = "Origem")]
        public string Origem { get; set; }
        
        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Display(Name = "Autonomia do Veículo (0.00)")]
        public string AutonomiaVeiculo { get; set; }

        [Display(Name = "Valor do Combustível (0.00)")]
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