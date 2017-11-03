using System;
using System.Collections.Generic;
using AvenueEntrega.Model.Entities;
using AvenueEntrega.Rules.UnitTest.Extensions;
using NUnit.Framework;

namespace AvenueEntrega.Rules.UnitTest
{
    [TestFixture]
    public class When_Defining_Mapa
    {
        private Mother _mother;
        private Mapa _testMapa;
        private Mapa _romeniaMapa;
        //private IList<Rota> _rotas;

        [SetUp]
        public void Init()
        {
            this._mother = new Mother();

            this._testMapa = _mother.CreateClientExampleMapa();

            this._romeniaMapa = _mother.CreateRomeniaMapa();
        }

        [Test]
        public void Test1_Verify_Possibilities_For_Each_State_in_Client_Example_Mapa_Will_Pass()
        {
            //Test Map (Example Taken from client requisites)
            Assert.IsTrue(_testMapa.PossibleActions("A").Count == 2);
            Assert.IsTrue(_testMapa.PossibleActions("B").Count == 3);
            Assert.IsTrue(_testMapa.PossibleActions("C").Count == 2);
            Assert.IsTrue(_testMapa.PossibleActions("D").Count == 3);
            Assert.IsTrue(_testMapa.PossibleActions("E").Count == 2);
        }

        [Test]
        public void Test2_Lower_Route_From_A_To_D_Will_Pass()
        {
            CalculoService service = new CalculoService(this._testMapa);

            var path = service.FindBestPath("A", "D");

            var expectedPath = new List<string>() { "A", "B",  "D" };

            if (path.Count == expectedPath.Count)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    Assert.IsTrue(path[i].Equals(expectedPath[i]));

                    Console.WriteLine("{0} == {1}", path[i], expectedPath[i]);
                }
            }
        }

        [Test]
        public void Test3_Lower_Cost_Route_From_A_To_D_Will_Pass()
        {
            CalculoService service = new CalculoService(this._testMapa);

            var result = service.Process("A", "D",10, 2.50m);

            Assert.IsTrue(result.CustoTotal == 6.25m);
        }

        [Test]
        public void Test4_Verify_Possibilities_For_Each_State_in_Romenia_Mapa_Will_Pass()
        {
            //Romenia Map (Example Taken from Stanford/Udacity MOOC 2011 - Introduction to Artificial Inteligence)
            Assert.IsTrue(_romeniaMapa.PossibleActions("Arad").Count == 3);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Zerind").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Oradea").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Sibiu").Count == 4);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Timisoara").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Lugoj").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Mehadia").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Drobeta").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Craiova").Count == 3);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Rimnicu Vilcea").Count == 3);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Fagaras").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Bucharest").Count == 4);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Pitesti").Count == 3);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Giurgiu").Count == 1);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Urziceni").Count == 3);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Hirsova").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Eforie").Count == 1);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Vaslui").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Iasi").Count == 2);
            Assert.IsTrue(_romeniaMapa.PossibleActions("Neamt").Count == 1);
        }

        [Test]
        public void Test5_Lower_Route_From_Arad_To_Bucharest_Will_Pass()
        {
            CalculoService service = new CalculoService(this._romeniaMapa);

            var path = service.FindBestPath("Arad", "Bucharest");

            var expectedPath = new List<string>() { "Arad", "Sibiu", "Rimnicu Vilcea", "Pitesti", "Bucharest" };

            if (path.Count == expectedPath.Count)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    Assert.IsTrue(path[i].Equals(expectedPath[i]));

                    Console.WriteLine("{0} == {1}", path[i], expectedPath[i]);
                }
            }
        }

        [Test]
        public void Test6_Lower_Cost_Route_From_Arad_To_Bucharest_Will_Pass()
        {
            CalculoService service = new CalculoService(this._romeniaMapa);

            var state = service.ChiepestFirstSearch("Arad", "Bucharest");

            Assert.IsTrue(state.Cost == 418.000m);
        }
    }
}
