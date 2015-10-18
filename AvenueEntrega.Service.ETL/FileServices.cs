using System;
using AvenueEntrega.I18N;
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
                    response.Message = Resources.FileServices_LoadMapaFromFile_Success_Message;
                }
                else
                {
                    response.Success = false;
                    response.Message = Resources.FileServices_LoadMapaFromFile_Fail_Message;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = Resources.FileServices_LoadMapaFromFile_Error_Message + ex.Message;
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
