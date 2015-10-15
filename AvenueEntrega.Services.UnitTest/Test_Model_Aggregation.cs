using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvenueEntrega.Model;
using NUnit.Framework;

namespace AvenueEntrega.Services.UnitTest
{
    [TestFixture]
    public class Test_Model_Aggregation
    {
        private Malha _malha;


        [SetUp]
        public void Init()
        {
            var mapa = new Mapa()
            {
                NomeMapa = "TestMap",
                Rotas = new List<Rota>()
                {
                    new Rota(){Origem = "A",Destino = "B", Custo = 10.0f},
                    new Rota(){Origem = "B",Destino = "D", Custo = 15.0f},
                    new Rota(){Origem = "A",Destino = "C", Custo = 20.0f},
                    new Rota(){Origem = "C",Destino = "D", Custo = 30.0f},
                    new Rota(){Origem = "B",Destino = "E", Custo = 50.0f},
                    new Rota(){Origem = "D",Destino = "E", Custo = 30.0f},
                }
            };
            this._malha = new Malha(mapa.Rotas);
        }

        [Test]
        public void When_Loading_Meshes_Verify_Counting_Edges_Will_Pass()
        {
            Assert.IsTrue(this._malha.Direcoes.ContainsKey("A"));
            Assert.IsTrue(this._malha.Direcoes["A"].Count == 2);
            Assert.IsTrue(this._malha.Direcoes.ContainsKey("B"));
            Assert.IsTrue(this._malha.Direcoes["B"].Count == 2);
            Assert.IsTrue(this._malha.Direcoes.ContainsKey("C"));
            Assert.IsTrue(this._malha.Direcoes["C"].Count == 1);
            Assert.IsTrue(this._malha.Direcoes.ContainsKey("D"));
            Assert.IsTrue(this._malha.Direcoes["D"].Count == 1);
            Assert.IsFalse(this._malha.Direcoes.ContainsKey("E"));
        }
    }
}
