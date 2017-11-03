using System;
using System.Collections.Generic;
using System.IO;
using AvenueEntrega.RepositoryFile.Dto;
using AvenueEntrega.RepositoryFile.Extensions;
using FileHelpers;

namespace AvenueEntrega.RepositoryFile
{
    public class RepositoryBase
    {
        private readonly string _repositoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);// + "//ObjectStore//";
        private DirectoryInfo _repositoryDirectory;

        public MapaRepositoryDto FindBy(string fileName, string name)
        {
            var engine = new FileHelperEngine<RotaRepositoryDto>();
            IList<RotaRepositoryDto> rotas = engine.ReadFile(fileName);

            var mapa = new MapaRepositoryDto();
            mapa.NomeMapa = name;
            mapa.Rotas = rotas.ExpandListaRotasRepositoryDto();
            
            return mapa;
        }

        
        public void Delete(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}