using System;
using AvenueEntrega.RepositoryFile;
using AvenueEntrega.RepositoryFile.Messages.Mapa;
using AvenueEntrega.Service.ETL.ExtensionMethods;

namespace AvenueEntrega.Service.ETL
{
    public class FileServices
    {
        private MapaFileRepository _mapaFileRepository;

        public FileServices(MapaFileRepository mapaFileRepository)
        {
            _mapaFileRepository = mapaFileRepository;
        }

        public CarregarMapaResponse LoadMapaFromFile(CarregarMapaRequest request)
        {
            var response = new CarregarMapaResponse();
            try
            {
                var result = _mapaFileRepository.FindBy(request.Arquivo, request.NomeMapa);
                if (result != null)
                {
                    response.Mapa = result;
                    response.Success = true;
                    response.Message = "Arquivo processado com sucesso.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Arquivo não encontrado.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro: " + ex.Message;
            }
            return response;
        }

        //public Mapa LoadMapaFromFile(string fileName, string name)
        //{
        //    var result = _mapaRepository.FindBy(fileName, name);

        //    if (result != null)
        //         return result.ConvertToMapa();

        //    return null;
        //}
    }
}
