using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.RepositoryNHibernate;
using AvenueEntrega.RepositoryNHibernate.Repositories;
using AvenueEntrega.ServiceContracts;
using AvenueEntrega.Services;
using AvenueEntrega.Web.MVC.ExtensionMethods;
using AvenueEntrega.Web.MVC.Models;

namespace AvenueEntrega.Web.MVC.Controllers
{
    public class MapaController : Controller
    {
        private IMapaService _mapaServices;

        public MapaController()
        {
            var unitOfWorkRepository = new NHUnitOfWorkRepository<Mapa>();
            var unitOfWork = new NHUnitOfWork<Mapa>(unitOfWorkRepository);
            var mapaRepository = new MapaRepository(unitOfWork);
            this._mapaServices = new MapaServices(mapaRepository);
        }

        public MapaController(IMapaService mapaServices)
        {
            _mapaServices = mapaServices;
        }

        //ActionResult - ListaMapas
        [HttpGet]
        public ActionResult Index()
        {
            var response = _mapaServices.EncontrarTodosMapas();

            ViewBag.Title = "Mapas Cadastrados";
            ViewBag.Message = response.Message;

            if (response.Success)
                return View("ListaMapas", response.Mapas.ConvertToListMapaViewModel());
            else
                return View("ListaMapas", new List<MapaViewModel>());
        }

        [HttpGet]
        public PartialViewResult CalcularCusto(string id)
        {
            var request = new EncontrarMapaPorRequest() {Mapa = new MapaDto() {Id = id} };

            var response = _mapaServices.EncontrarMapaPor(request);

            if (!response.Success)
            {
                return PartialView("Error");
            }

            var origens = response.Mapa.Rotas.ConvertToListRotaOrigemViewMode();
            var destinos = response.Mapa.Rotas.ConvertToListRotaDestinoViewMode();
            
            var calculo = new CalculoCustoViewModel()
            {
                Origens = origens,
                Destinos = destinos,
                Autonomia = "0.00",
                ValorCombustivel = "0.00"
            };

            return PartialView("CalcularCusto", calculo);
        }
    }
}