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
    public class Class1
    {
        private Malha _malha;
        private Mapa _mapa;


        [SetUp]

        public void Init()
        {
            this._malha = new Malha();

            this._mapa = new Mapa()
            {
                NomeMapa = "TestMap",
                Malha = new List<Rota>()
                {
                    new Rota(){Origem = "A",Destino = "B", Custo = 10.0f},
                    new Rota(){Origem = "B",Destino = "D", Custo = 15.0f},
                    new Rota(){Origem = "A",Destino = "C", Custo = 20.0f},
                    new Rota(){Origem = "C",Destino = "D", Custo = 30.0f},
                    new Rota(){Origem = "B",Destino = "E", Custo = 50.0f},
                    new Rota(){Origem = "D",Destino = "E", Custo = 30.0f},
                }
            };
        }

        [Test]
        public void When_Loading_Meshes_Verify_Counting_Edges_Will_Pass()
        {
            foreach (var rota in _mapa.Malha)
            {
                if (this._malha.Direcoes.ContainsKey(rota.Origem))
                {
                    
                    //add/update
                    this._malha.Direcoes[rota.Origem].Add(rota);
                }
                else
                {
                    //create
                    this._malha.Direcoes.Add(rota.Origem, new List<Rota>(){rota});
                }
            }

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
