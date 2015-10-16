using System;
using System.Collections.Generic;
using System.IO;
using AvenueEntrega.RepositoryFile.Dto;
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
            mapa.Rotas = rotas;
            
            return mapa;

            //try
            //{
            //    if (!Directory.Exists(this._repositoryPath))
            //    {
            //        _repositoryDirectory = Directory.CreateDirectory(this._repositoryPath);
            //    }
            //    else
            //    {
            //        this._repositoryDirectory = new DirectoryInfo(this._repositoryPath);
            //    }

            //    bool wasLoaded = false;

            //    try
            //    {
            //        if (String.IsNullOrEmpty(fileName))
            //        {
            //            throw new ArgumentNullException("fileName", "Filename cannot be null or empty.");

            //        }
            //        else
            //        {
            //            //T deserializedObject;
            //            //XmlSerializer serializer = new XmlSerializer(typeof(T));
            //            using (TextReader textReader = new StreamReader(fileName))
            //            {
            //                //deserializedObject = (T)serializer.Deserialize(textReader);
            //            }

            //            //return deserializedObject;

            //        }

            //        //T wikiObject = PersistenceManager.DeserializeObject<T>(fileName, this.repositoryPath, this.fileExtension);
            //        //if (wikiObject != null)
            //        //{
            //        //    this.documents.Add(fileName, wikiObject);
            //        //    wasLoaded = true;
            //        //}
            //    }
            //    catch (InvalidOperationException ex)
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            ////throw new System.NotImplementedException();
        }

        
        public void Delete(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}