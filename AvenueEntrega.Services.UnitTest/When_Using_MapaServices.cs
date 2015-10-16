using AvenueEntrega.DataContracts.Dto;
using AvenueEntrega.DataContracts.Messages.Mapa;
using AvenueEntrega.DataContracts.Messages.Problema;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;
using AvenueEntrega.Services.ExtensionMethods;
using NUnit.Framework;
using Rhino.Mocks;

namespace AvenueEntrega.Services.UnitTest
{
    [TestFixture]
    public class When_Using_MapaServices
    {
        private Mother _mother;
        private MapaServices _mapaServices;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
        }

        [Test]
        public void Test1_Registring_Map_Will_Pass()
        {
            var mapa = _mother.CreateRomeniaMapa();

            var request = new InserirMapaRequest()
            {
                Mapa = mapa.ConvertoToMapaDto()
            };

            //Arrange
            var mapaRepository = MockRepository.GenerateMock<IMapaRepository>();
            mapaRepository.Stub(x => x.Save(Arg<Mapa>.Is.Anything));

            //Act
            _mapaServices = new MapaServices(mapaRepository);
            var result = _mapaServices.InserirMapa(request);
            
            //Assert
            Assert.IsTrue(result.Success);
            mapaRepository.VerifyAllExpectations();
        }

        [Test]
        public void Test2_Finding_Map_Will_Pass()
        {
            var mapa = _mother.CreateRomeniaMapa();

            var request = new EncontrarMapaPorRequest()
            {
                Mapa = new MapaDto() { NomeMapa = "Romenia"}
            };

            //Arrange
            var mapaRepository = MockRepository.GenerateMock<IMapaRepository>();
            mapaRepository.Stub(x => x.FindByName("Romenia")).Return(mapa);

            //Act
            _mapaServices = new MapaServices(mapaRepository);
            var result = _mapaServices.EncontrarMapaPor(request);

            //Assert
            Assert.IsTrue(result.Success);
            mapaRepository.VerifyAllExpectations();
        }

        [Test]
        public void Test3_Finding_BestPath_Will_Pass()
        {
            var mapa = _mother.CreateClientExampleMapa();

            var resquest = new CalcularMelhorRotaRequest()
            {
                Problema = new ProblemaDto() { NomeMapa = "TestMap",Origem = "A",Destino = "D",AutonomiaVeiculo = "10",ValorCombustivel = "2.50"}
            };

            //Arrange
            var mapaRepository = MockRepository.GenerateMock<IMapaRepository>();
            mapaRepository.Stub(x => x.FindByName("TestMap")).Return(mapa);

            //Act
            _mapaServices = new MapaServices(mapaRepository);
            var result = _mapaServices.CalcularRota(resquest);

            //Assert
            Assert.IsTrue(result.Success);
            mapaRepository.VerifyAllExpectations();
        }
    }
}
