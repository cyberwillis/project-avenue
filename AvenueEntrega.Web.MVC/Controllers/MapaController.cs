using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.DataContracts.Messages.Problema;
using AvenueEntrega.I18N;
using AvenueEntrega.Infrastructure;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.RepositoryFile;
using AvenueEntrega.RepositoryFile.Messages.Mapa;
using AvenueEntrega.RepositoryNHibernate;
using AvenueEntrega.RepositoryNHibernate.Repositories;
using AvenueEntrega.Service.ETL;
using AvenueEntrega.Service.ETL.ExtensionMethods;
using AvenueEntrega.ServiceContracts;
using AvenueEntrega.Services;
using AvenueEntrega.Services.ExtensionMethods;
using AvenueEntrega.Web.MVC.ExtensionMethods;
using AvenueEntrega.Web.MVC.Models;
using WebGrease.Css.Extensions;

namespace AvenueEntrega.Web.MVC.Controllers
{
    public class MapaController : ControllerBase
    {
        private IMapaService _mapaServices;
        private FileServices _fileServices;

        public MapaController()
        {
            var unitOfWorkRepository = new NHUnitOfWorkRepository<Mapa>();
            var unitOfWork = new NHUnitOfWork<Mapa>(unitOfWorkRepository);
            var mapaRepository = new MapaRepository(unitOfWork);
            this._mapaServices = new MapaServices(mapaRepository);

            var fileRepostory = new MapaFileRepository();
            this._fileServices = new FileServices(fileRepostory);
        }

        public MapaController(IMapaService mapaServices)
        {
            _mapaServices = mapaServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = Resources.MapaController_HttpGet_Action_Index_ViewBag_Title; //"Mapas Cadastrados"

            var response = _mapaServices.EncontrarTodosMapas();
            if (response.Success)
            {
                ViewBag.MessageType = "alert-info";
                ViewBag.Message = response.Message;

                var model = response.Mapas.ConvertToListMapaViewModel();

                return View("ListaMapas", model);
            }
            else
            {
                ViewBag.MessageType = "alert-warning";
                ViewBag.Message = response.Message;

                var model = new List<MapaViewModel>();

                return View("ListaMapas", model);
            }
        }

        //ActionResult - ListaMapas
        [HttpGet]
        public PartialViewResult List()
        {
            ViewBag.Title = Resources.MapaController_HttpGet_Action_List_ViewBag_Title;//"Mapas Cadastrados"

            var response = _mapaServices.EncontrarTodosMapas();
            if (response.Success)
            {
                ViewBag.MessageType = "alert-info";
                ViewBag.Message = response.Message;

                var model = response.Mapas.ConvertToListMapaViewModel();
                return PartialView("ListaMapasPartialView", model);
            }
            else
            {
                ViewBag.MessageType = "alert-warning";
                ViewBag.Message = response.Message;

                var model = new List<MapaViewModel>();
                return PartialView("ListaMapasPartialView", model);
            }
        }

        [HttpGet]
        public PartialViewResult CalcularCusto(string id)
        {
            ViewBag.Title = Resources.MapaController_HttpGet_Action_CalcularCusto_ViewBag_Title; //"Calcular custo para o trajeto:"

            var request = new EncontrarMapaPorRequest() {Mapa = new MapaDto() {Id = id} };
            var response = _mapaServices.EncontrarMapaPor(request);

            if (response.Success)
            {
                ViewBag.MessageType = "alert-warning";
                ViewBag.Message = Resources.MapaController_HttpGet_Action_CalcularCusto_ViewBag_Message;//"Utilize esta ferramenta para calcular o menor trajeto e seu custo.";

                var origens = response.Mapa.Rotas.ConvertToListRotaOrigemViewMode();
                var destinos = response.Mapa.Rotas.ConvertToListRotaDestinoViewMode();

                var model = new CalculoCustoViewModel()
                {
                    Id = id,
                    NomeMapa = response.Mapa.NomeMapa,
                    Origens = origens,
                    Destinos = destinos,
                    AutonomiaVeiculo = "0.00",
                    ValorCombustivel = "0.00"
                };

                return PartialView("CalcularCustoPartialView", model);
            }
            else
            {
                ViewBag.MessageType = "alert-danger";
                ViewBag.Message = response.Message;

                return PartialView("SucessoPartialView");
            }
        }

        [HttpPost]
        public PartialViewResult CalcularCusto(CalculoCustoViewModel model, FormCollection forms)
        {
            ViewBag.Title =Resources.MapaController_HttpPost_Action_CalcularCusto_ViewBag_Title;//"Calculadora de Rota e Custo:";
            
            model.Origem = forms["Origens"];
            model.Destino = forms["Destinos"];

            //Fix to compromise the calculation if one of the states was not set
            //Selecione
            if (model.Origem.Equals(Resources.SelectList_Null_Item))
                model.Origem = string.Empty;

            //Selecione
            if (model.Destino.Equals(Resources.SelectList_Null_Item))
                model.Destino = string.Empty;
            
            var request = new CalcularMelhorRotaRequest(){ Problema = new ProblemaDto()
            {
                Id = model.Id, 
                NomeMapa = model.NomeMapa,
                Origem = model.Origem,
                Destino = model.Destino,
                AutonomiaVeiculo = model.AutonomiaVeiculo,
                ValorCombustivel = model.ValorCombustivel,
            } };
            var response = _mapaServices.CalcularRota(request);

            if (response.Success)
            {
                ViewBag.MessageType = "alert-success";
                ViewBag.Message = response.Message;

                var caminho = new StringBuilder();
                foreach (var state in response.MelhorCaminho)
                {
                    caminho.Append(state);
                    caminho.Append(" > ");
                }

                var resultado = new ResultadoCustoViewModel()
                {
                    Id = model.Id,
                    NomeMapa = model.NomeMapa,
                    Caminho = caminho.ToString(),
                    CustoTotal = response.CustoTotal
                };
                return PartialView("ResultadoCustoPartialView", resultado);
            }
            else
            {
                ViewBag.Title = Resources.MapaController_HttpPost_Action_CalcularCusto_ViewBag_Title;//"Calculadora de Rota e Custo:";
                

                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value));
                var requestMapa = new EncontrarMapaPorRequest() { Mapa = new MapaDto() { Id = model.Id, NomeMapa = model.NomeMapa} };
                var responseMapa = _mapaServices.EncontrarMapaPor(requestMapa);
                if (responseMapa.Success)
                {
                    ViewBag.MessageType = "alert-warning";
                    ViewBag.Message = response.Message;

                    var origens = responseMapa.Mapa.Rotas.ConvertToListRotaOrigemViewMode();
                    var destinos = responseMapa.Mapa.Rotas.ConvertToListRotaDestinoViewMode();
                    model.Destinos = destinos;
                    model.Origens = origens;
                    return PartialView("CalcularCustoPartialView", model);
                }
                else
                {
                    ViewBag.MessageType = "alert-danger";
                    ViewBag.Message = response.Message;

                    return PartialView("SucessoPartialView");
                }
            }
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.Title = Resources.MapaController_HttpGet_Action_Create_ViewBag_Title;//"Cadastrar novo Mapa";

            ViewBag.MessageType = "alert-warning";
            ViewBag.Message = Resources.MapaController_HttpGet_Action_Create_ViewBag_Message;//"Utilize esta ferramenta para cadastrar um novo mapa. Se o mapa já existir ele sera removido e re-criado.";

            var model = new CadastrarMapaViewModel();

            return PartialView("CadastrarMapaPartialView", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> Create(string id,FormCollection form)
        {
            ViewBag.Title = Resources.MapaController_HttpPost_Action_Create_ViewBag_Title;//"Cadastrar novo Mapa";

            string filePath = string.Empty;

            try
            {
                string nomeMapa = form["NomeMapa"];

                if (!string.IsNullOrEmpty(nomeMapa))
                {
                    var uploadComplete = false;

                    //processa upload de arquivos
                    foreach (string file in Request.Files)
                    {
                        uploadComplete = true;
                        var fileContent = Request.Files[file];
                        if (fileContent != null && fileContent.ContentLength > 0 &&
                            !string.IsNullOrEmpty(fileContent.FileName))
                        {
                            string fileName = Path.GetFileName(fileContent.FileName);
                            filePath = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
                            fileContent.SaveAs(filePath);
                        }
                    }

                    if (uploadComplete)
                    {
                        var response =
                            _fileServices.LoadMapaFromFile(new CarregarMapaRequest()
                            {
                                NomeMapa = nomeMapa,
                                Arquivo = filePath
                            });
                        if (response.Success)
                        {
                            var mapaRepositoryDto = response.Mapa;
                            var mapa = mapaRepositoryDto.ConvertToMapa();
                            var mapaDto = mapa.ConvertoToMapaDto();

                            var resp = _mapaServices.InserirMapa(new InserirMapaRequest() {Mapa = mapaDto});

                            if (resp.Success)
                            {
                                ViewBag.MessageType = "alert-success";
                                ViewBag.Message = response.Message;

                                return PartialView("SucessoPartialView");
                            }
                        }
                        else
                        {
                            ViewBag.MessageType = "alert-danger";
                            ViewBag.Message = response.Message;
                            //ModelState.AddModelError("File", response.Message);

                            var model = new CadastrarMapaViewModel() {NomeMapa = nomeMapa};

                            return PartialView("CadastrarMapaPartialView", model);
                        }
                    }
                    else
                    {
                        ViewBag.MessageType = "alert-danger";
                        ViewBag.Message = Resources.MapaController_HttpPost_Action_Create_ViewBag_Message;//"O arquivo de carga precisa ser especificado.";
                        //ModelState.AddModelError("File", response.Message);

                        var model = new CadastrarMapaViewModel() {NomeMapa = nomeMapa};

                        return PartialView("CadastrarMapaPartialView", model);


                        //ViewBag.MessageType = "alert-danger";
                        //ViewBag.Message = "Ocorreu um erro interno, tente novamente";

                        //return PartialView("SucessoPartialView");
                    }
                }
                else
                {
                    ViewBag.MessageType = "alert-danger";
                    ViewBag.Message = Resources.MapaController_HttpPost_Action_Create_ViewBag_Message2;//"O nome do mapa precisa ser especificado";

                    //ModelState.AddModelError("NomeMapa","O nome do mapa precisa ser especificado");

                    var model = new CadastrarMapaViewModel();

                    return PartialView("CadastrarMapaPartialView", model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.MessageType = "alert-danger";
                ViewBag.Message = "Erro: " + ex.Message;

                var model = new CadastrarMapaViewModel();

                return PartialView("CadastrarMapaPartialView", model);
            }
            finally
            {
                if (!string.IsNullOrEmpty(filePath))
                    System.IO.File.Delete(filePath);
            }

            return null;
        }
        
        [HttpGet]
        public PartialViewResult Delete(string id)
        {
            ViewBag.Title = Resources.MapaController_HttpGet_Action_Delete_ViewBag_Title;//"Excluir mapa";

            var request = new EncontrarMapaPorRequest() { Mapa = new MapaDto() { Id = id } };
            var response = _mapaServices.EncontrarMapaPor(request);

            if (response.Success)
            {
                ViewBag.MessageType = "alert-danger";
                ViewBag.Message = Resources.MapaController_HttpGet_Action_Delete_ViewBag_Message;//"Deseja realmente excluir este mapa ? ";

                var model = new ExcluirMapaViewModel() {Id = id, NomeMapa = response.Mapa.NomeMapa};

                return PartialView("ExcluirMapaPartialView", model);
            }
            else
            {
                ViewBag.MessageType = "alert-danger";
                ViewBag.Message = response.Message;

                return PartialView("SucessoPartialView");
            }
        }

        [HttpPost]
        public PartialViewResult Delete(ExcluirMapaViewModel model)
        {
            ViewBag.Title = Resources.MapaController_HttpPost_Action_Delete_ViewBag_Title;//"Excluir mapa";
            
            var request = new ExcluirMapaRequest() {Mapa = new MapaDto() {Id = model.Id, NomeMapa = model.NomeMapa}};
            var response = _mapaServices.ExcluirMapa(request);

            if (!response.Success)
            {
                ViewBag.MessageType = "alert-warning";
                ViewBag.Message = response.Message;

                return PartialView("ExcluirMapaPartialView", model);
            }
            else
            {
                ViewBag.MessageType = "alert-success";
                ViewBag.Message = response.Message;

                return PartialView("SucessoPartialView");
            }
        }


        public RedirectResult SetCulture(string culture, string url)
        {
            culture = CultureHelper.GetImplementedCulture(culture);

            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture;
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);

            return Redirect(url);
            //return RedirectToAction("Index");
        }
    }
}