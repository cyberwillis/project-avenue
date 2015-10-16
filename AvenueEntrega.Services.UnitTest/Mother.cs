using System.Collections.Generic;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Services.UnitTest
{
    /// <summary>
    /// TDD ObjectMotherPattern
    /// http://martinfowler.com/bliki/ObjectMother.html
    /// For Complex class or business rules use Test Data Builder Pattern
    /// http://geekswithblogs.net/Podwysocki/archive/2008/01/08/118362.aspx
    /// </summary>
    public class Mother
    {
        public Mapa CreateRomeniaMapa()
        {
            var mapa = new Mapa()
            {
                NomeMapa = "Romenia",
                Rotas = new List<Rota>()
                {
                    new Rota(){Origem = "Arad",Destino = "Zerind", Custo = 75.0m},
                    new Rota(){Origem = "Zerind",Destino = "Oradea", Custo = 71.0m},
                    new Rota(){Origem = "Oradea",Destino = "Sibiu", Custo = 151.0m},
                    new Rota(){Origem = "Sibiu",Destino = "Arad", Custo = 140.0m},
                    new Rota(){Origem = "Arad",Destino = "Timisoara", Custo = 118.0m},
                    new Rota(){Origem = "Timisoara",Destino = "Lugoj", Custo = 111.0m},
                    new Rota(){Origem = "Lugoj",Destino = "Mehadia", Custo = 70.0m},
                    new Rota(){Origem = "Mehadia",Destino = "Drobeta", Custo = 75.0m},
                    new Rota(){Origem = "Drobeta",Destino = "Craiova", Custo = 120.0m},
                    new Rota(){Origem = "Craiova",Destino = "Rimnicu Vilcea", Custo = 146.0m},
                    new Rota(){Origem = "Rimnicu Vilcea",Destino = "Sibiu", Custo = 80.0m},
                    new Rota(){Origem = "Sibiu",Destino = "Fagaras", Custo = 99.0m},
                    new Rota(){Origem = "Fagaras",Destino = "Bucharest", Custo = 211.0m},
                    new Rota(){Origem = "Bucharest",Destino = "Pitesti", Custo = 101.0m},
                    new Rota(){Origem = "Pitesti",Destino = "Rimnicu Vilcea", Custo = 97.0m},
                    new Rota(){Origem = "Craiova",Destino = "Pitesti", Custo = 138.0m},
                    new Rota(){Origem = "Bucharest",Destino = "Giurgiu", Custo = 90.0m},
                    new Rota(){Origem = "Bucharest",Destino = "Urziceni", Custo = 85.0m},
                    new Rota(){Origem = "Urziceni",Destino = "Hirsova", Custo = 98.0m},
                    new Rota(){Origem = "Hirsova",Destino = "Eforie", Custo = 86.0m},
                    new Rota(){Origem = "Urziceni",Destino = "Vaslui", Custo = 142.0m},
                    new Rota(){Origem = "Vaslui",Destino = "Iasi", Custo = 92.0m},
                    new Rota(){Origem = "Iasi",Destino = "Neamt", Custo = 87.0m},
                }
            };
            return mapa;
        }

        public Mapa CreateClientExampleMapa()
        {
            var mapa = new Mapa()
            {
                NomeMapa = "TestMap",
                Rotas = new List<Rota>()
                {
                    new Rota(){Origem = "A",Destino = "B", Custo = 10.0m},
                    new Rota(){Origem = "B",Destino = "D", Custo = 15.0m},
                    new Rota(){Origem = "A",Destino = "C", Custo = 20.0m},
                    new Rota(){Origem = "C",Destino = "D", Custo = 30.0m},
                    new Rota(){Origem = "B",Destino = "E", Custo = 50.0m},
                    new Rota(){Origem = "D",Destino = "E", Custo = 30.0m},
                }
            };
            return mapa;
        }
    }
}