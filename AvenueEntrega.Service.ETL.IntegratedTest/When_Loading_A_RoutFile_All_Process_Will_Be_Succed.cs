using System;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.RepositoryFile;
using AvenueEntrega.RepositoryFile.Messages.Mapa;
using AvenueEntrega.RepositoryNHibernate;
using AvenueEntrega.RepositoryNHibernate.Repositories;
using AvenueEntrega.Service.ETL.ExtensionMethods;
using NUnit.Framework;

namespace AvenueEntrega.Service.ETL.IntegratedTest
{
    [TestFixture]
    public class When_Loading_A_RoutFile_All_Process_Will_Be_Succed
    {
        private FileServices _fileServices;
        private string _fileName;

        [SetUp]
        public void Init()
        {
            this._fileName = AppDomain.CurrentDomain.BaseDirectory + "\\TestMapa.txt";

            //string codeBase = Assembly.GetExecutingAssembly().FullName;
            //UriBuilder uri = new UriBuilder(codeBase);
            //string filePath = Uri.UnescapeDataString(uri.Path);
            //this._fileName = codeBase; //filePath += "\\" + this._fileName;
            //Path.GetDirectoryName(path);

            var fileRepository = new MapaFileRepository();
            var mapaRepository = new MapaRepository(new NHUnitOfWork<Mapa>(new NHUnitOfWorkRepository<Mapa>()));

            this._fileServices = new FileServices(fileRepository);
        }

        [Test]
        public void Test1_Loading_ClientExampleFile_Will_Pass()
        {
            var nomeMapa = "MyMap";
            
            var request = new CarregarMapaRequest()
            {
                NomeMapa = nomeMapa,
                Arquivo = this._fileName
            };

            var response = this._fileServices.LoadMapaFromFile(request);

            var mapa = response.Mapa.ConvertToMapa();

            foreach (var rota in mapa.Rotas)
            {
                Console.WriteLine("{0} -> {1} = {2}", rota.Origem, rota.Destino, rota.Custo);
            }

            Assert.IsTrue(mapa.NomeMapa.Equals(nomeMapa));
            Assert.IsTrue(mapa.Rotas.Count == 6);
        }
    }
}
