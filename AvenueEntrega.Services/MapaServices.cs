using System;
using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.DataContracts.Messages.Problema;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;
using AvenueEntrega.Rules;
using AvenueEntrega.ServiceContracts;
using AvenueEntrega.Services.ExtensionMethods;

namespace AvenueEntrega.Services
{
    public class MapaServices : IMapaService
    {
        private readonly IMapaRepository _mapaRepository;

        public MapaServices(IMapaRepository mapaRepository)
        {
            _mapaRepository = mapaRepository;
        }
        
        public EncontrarTodosMapasResponse EncontrarTodosMapas()
        {
            var response = new EncontrarTodosMapasResponse();
            try
            {
                var mapas = _mapaRepository.FindAll();
                if (mapas != null)
                {
                    response.Success = true;
                    response.Message = string.Format("Encontrado(s) {0} mapas", mapas.Count);
                    response.Mapas = mapas.ConvertToListMapasDto();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Nenhum papa encontrado.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }

        public EncontrarMapaPorResponse EncontrarMapaPor(EncontrarMapaPorRequest request)
        {
            Mapa mapa = null;
            Guid id;
            string nomeMapa;

            var response = new EncontrarMapaPorResponse();
            try
            {
                //Opcoes de Busca
                if (!string.IsNullOrEmpty(request.Mapa.Id))
                {
                    id = Guid.Parse(request.Mapa.Id);
                    mapa = _mapaRepository.FindBy(id);
                }
                else if (!string.IsNullOrEmpty(request.Mapa.NomeMapa))
                {
                    nomeMapa = request.Mapa.NomeMapa;
                    mapa = _mapaRepository.FindByName(nomeMapa);
                }
                
                if (mapa != null)
                {
                    response.Success = true;
                    response.Message = "Mapa encontrado.";
                    response.Mapa = mapa.ConvertoToMapaDto();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Mapa não encontrado.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }

        public InserirMapaResponse InserirMapa(InserirMapaRequest request)
        {
            var response = new InserirMapaResponse();
            try
            {
                var mapa = request.Mapa.ConvertToMapa();
                if (mapa.IsValid())
                {
                    //removes the old
                    var oldMapa = _mapaRepository.FindByName(mapa.NomeMapa);
                    if (oldMapa != null)
                    {
                        _mapaRepository.Delete(oldMapa);
                        _mapaRepository.Persist();
                    }

                    //persist the new
                    _mapaRepository.Save(mapa);
                    _mapaRepository.Persist();

                    response.Success = true;
                    response.Message = "Inserido com sucesso.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Erro:" + mapa.GetErrorMessages();
                    response.Rules = mapa.BrokenRules;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }

        public AlterarMapaResponse AlterarMapa(AlterarMapaRequest request)
        {
            var response = new AlterarMapaResponse();
            try
            {
                var nome = request.Mapa.ConvertToMapa().NomeMapa;

                var mapa = _mapaRepository.FindByName(nome);
                if (mapa!= null)
                {
                    var novoMapa = request.Mapa.ConvertToMapa();

                    if (novoMapa.IsValid())
                    {
                        _mapaRepository.Delete(mapa);

                        _mapaRepository.Save(mapa);

                        _mapaRepository.Persist();

                        response.Success = true;
                        response.Message = "Excluido com sucesso.";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Erro: " + novoMapa.GetErrorMessages();
                        response.Rules = novoMapa.BrokenRules;
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Mapa não encontrado.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }

        public ExcluirMapaResponse ExcluirMapa(ExcluirMapaRequest request)
        {
            var response = new ExcluirMapaResponse();
            try
            {
                var id = request.Mapa.ConvertToMapa().Id;

                var mapa = _mapaRepository.FindBy(id);

                if (mapa != null)
                {
                    _mapaRepository.Delete(mapa);
                    _mapaRepository.Persist();

                    response.Success = true;
                    response.Message = "Excluido com sucesso.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Mapa não encontrada.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }

        public CalcularMelhorRotaResponse CalcularRota(CalcularMelhorRotaRequest request)
        {
            var response = new CalcularMelhorRotaResponse();
            try
            {
                var problema = request.Problema.ConvertToProblema();
                if (problema.IsValid())
                {
                    CalculoService servicoDeCalculo;
                    Mapa mapa = null;

                    if (!string.IsNullOrEmpty(problema.Id))
                    {
                        var id = Guid.Parse(problema.Id);
                        mapa = _mapaRepository.FindBy(id);
                    }
                    else if(!string.IsNullOrEmpty(problema.NomeMapa))
                    {
                        var nomeMapa = problema.NomeMapa;
                        mapa = _mapaRepository.FindByName(nomeMapa);
                    }
                    
                    if (mapa != null)
                    {
                        servicoDeCalculo = new CalculoService(mapa);

                        var result = servicoDeCalculo.Process(  problema.Origem,
                                                                problema.Destino,
                                                                problema.AutonomiaVeiculo,
                                                                problema.ValorCombustivel);

                        response.Success = true;
                        response.Message = "Operação executada com sucesso.";
                        response.CustoTotal = result.CustoTotal.ToString();
                        response.MelhorCaminho = result.MelhorCaminho;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Mapa não encontrado.";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Erro:" + problema.GetErrorMessages();
                    response.Rules = problema.BrokenRules;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }
    }
}
