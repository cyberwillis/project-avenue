using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Model.Repository;
using AvenueEntrega.RepositoryNHibernate;
using AvenueEntrega.RepositoryNHibernate.Repositories;
using NUnit.Framework;

namespace AvenueEntrega.RepositoryNHIbernate.IntegratedTest
{
    [TestFixture]
    public class MapaRepository_Tests
    {
        private IMapaRepository _mapaRepository;
        private IUnitOfWork<Mapa> _unitOfWork;
        private IUnitOfWorkRepository<Mapa> _unitOfWorkRepository;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();

            _unitOfWorkRepository = new NHUnitOfWorkRepository<Mapa>();
            _unitOfWork = new NHUnitOfWork<Mapa>(_unitOfWorkRepository);
            _mapaRepository = new MapaRepository(_unitOfWork);
        }

        [TearDown]
        public void Finish()
        {
            //Todo: dispose something if needed
        }

        [Test]
        public void Test1_EncontrarMapasPorNome()
        {
            var mapa = _mother.CreateRomeniaMapa();

            _mapaRepository.Save(mapa);
            _mapaRepository.Persist();

            var temp = _mapaRepository.FindByName(mapa.NomeMapa);

            Assert.IsTrue(temp!= null);

            //_mapaRepository.Delete(temp);
            //_mapaRepository.Persist();
        }
    }
}
