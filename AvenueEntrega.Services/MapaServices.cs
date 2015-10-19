using System;
using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.DataContracts.Messages.Problema;
using AvenueEntrega.I18N;
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
                    response.Message = string.Format(@Resources.MapaServices_EncontrarTodosMapas_Success_Message, mapas.Count);
                    response.Mapas = mapas.ConvertToListMapasDto();
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_EncontrarTodosMapas_Failed_Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_EncontrarTodosMapas_Error_Message + ex.Message;
            }
            return response;
        }

        public EncontrarTodosMapasPorResponse EncontrarTodosMapasPor(EncontrarTodosMapasPorRequest request)
        {
            var response = new EncontrarTodosMapasPorResponse();
            try
            {
                var nomeMapa = request.Mapa.NomeMapa;
                var mapas = _mapaRepository.FindAllByName(nomeMapa);
                if (mapas != null)
                {
                    response.Success = true;
                    response.Message = Resources.MapaServices_EncontrarTodosMapasPor_Success_Message;
                    response.Mapas = mapas.ConvertToListMapasDto();
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_EncontrarTodosMapasPor_Fail_Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_EncontrarTodosMapasPor_Error_Message + ex.Message;
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
                    response.Message = Resources.MapaServices_EncontrarMapaPor_Success_Message;
                    response.Mapa = mapa.ConvertoToMapaDto();
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_EncontrarMapaPor_Fail_Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_EncontrarMapaPor_Error_Message + ex.Message;
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
                    response.Message = Resources.MapaServices_InserirMapa_Success_Message;
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_InserirMapa_Fail_Message + mapa.GetErrorMessages();
                    response.Rules = mapa.BrokenRules;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_InserirMapa_Error_Message + ex.Message;
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
                        response.Message = Resources.MapaServices_AlterarMapa_Success_Message;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = Resources.MapaServices_AlterarMapa_Fail_Message + novoMapa.GetErrorMessages();
                        response.Rules = novoMapa.BrokenRules;
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_AlterarMapa_Fail2_Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_AlterarMapa_Error_Message + ex.Message;
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
                    response.Message = Resources.MapaServices_ExcluirMapa_Success_Message;
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_ExcluirMapa_Fail_Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_ExcluirMapa_Error_Message + ex.Message;
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
                        response.Message = Resources.MapaServices_CalcularRota_Success_Message;
                        response.CustoTotal = result.CustoTotal.ToString();
                        response.MelhorCaminho = result.MelhorCaminho;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = Resources.MapaServices_CalcularRota_Fail_Message;
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.MapaServices_CalcularRota_Fail2_Message + problema.GetErrorMessages();
                    response.Rules = problema.BrokenRules;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.MapaServices_CalcularRota_Error_Message + ex.Message;
            }
            return response;
        }
    }
}
