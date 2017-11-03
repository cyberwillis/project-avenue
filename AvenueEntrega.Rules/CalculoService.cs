using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.Model.Entities;

namespace AvenueEntrega.Rules
{
    public class CalculoService
    {
        private Mapa _mapa;
        
        private IList<Rota> _rotas;

        public CalculoService(Mapa mapa)
        {
            this._mapa = mapa;

            this._rotas = CopyFrom(mapa.Rotas);
        }

        /// <summary>
        /// This method is used to process the best path and calculate the cost for it.
        /// </summary>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <param name="autonomiaDoVeiculo"></param>
        /// <param name="valorDoLitroDeCombustivel"></param>
        /// <returns></returns>
        public ResultadoCalculo Process(string origem, string destino, decimal autonomiaDoVeiculo, decimal valorDoLitroDeCombustivel)
        {
            this._rotas = CopyFrom(this._mapa.Rotas);

            //Finds Best path
            State state = ChiepestFirstSearch(origem, destino);

            ResultadoCalculo result= null;

            if (state != null)
            {
                //Calculates best cost
                decimal custoTotalDeDeslocamento = CalculateBestCost(state.Cost, autonomiaDoVeiculo, valorDoLitroDeCombustivel);
                result = new ResultadoCalculo()
                {
                    MelhorCaminho = state.GetPath(),
                    CustoTotal = custoTotalDeDeslocamento
                };
            }
            
            return result;
        }

        /// <summary>
        /// This method is use, just to make de calculation
        /// </summary>
        /// <param name="custoDeslocamento"></param>
        /// <param name="autonomiaDoVeiculo"></param>
        /// <param name="valorDoLitroDeCombustivel"></param>
        /// <returns></returns>
        private decimal CalculateBestCost(decimal custoDeslocamento, decimal autonomiaDoVeiculo, decimal valorDoLitroDeCombustivel)
        {
            return (custoDeslocamento / autonomiaDoVeiculo) * valorDoLitroDeCombustivel;
        }

        /// <summary>
        /// This method is used ONLY to get the best path found and total cost to that path.
        /// </summary>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public IList<string> FindBestPath(string origem, string destino)
        {
            this._rotas = CopyFrom(this._mapa.Rotas);

            State state = ChiepestFirstSearch(origem, destino);

            return state.GetPath();
        }

        /// <summary>
        /// This Method Calculates the best Path from start point to the goal, using the Search Algorithm Uniform Cost Search (Chipest First)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public State ChiepestFirstSearch(string start, string goal)
        {
            State initialState = new State(start, null, 0.0m);
            IList<State> paths = new List<State>();
            IList<State> exploreds = new List<State>();
            IList<State> frontiers = new List<State>();
            frontiers.Add(initialState);

            Action<State> addStateToExploredList = (state) => { exploreds.Add(state); };
            Action<IList<State>> addToFrontiersList = (list) => { foreach (var item in list) { frontiers.Add(item); } };
            Action<State> removeFromFrontiersList = (state) => { frontiers.Remove(state); };
            Action<State> addToGoalsList = (state) => { paths.Add(state); };
            Action<IList<State>, decimal> removeStatesFromFrontierWithCostBiggerThanGoal = (listFrontiers, lowerCostToGoal) =>
            {
                for (var i = 0 ; i < listFrontiers.Count; i++ )
                {
                    State frontier = listFrontiers[i];

                    if (frontier.Cost > lowerCostToGoal)
                    {
                        listFrontiers.RemoveAt(i);
                        i--;
                    }
                }
            };
            Func<string,decimal,IList<State>,decimal> verifyIfTheGoalIsInsideTheFrontierAndGetItsLowestCostVersion = (g,c,fs) =>
            {
                for (var i = 0; i < fs.Count; i++)
                {
                    if (fs[i].Name.Equals(g))
                    {
                        if (c > fs[i].Cost)
                            c = fs[i].Cost;
                    }
                }
                return c;
            };
            Func<State, IList<State>> expandStateAndGetNewFrontiersNearBy = (state) =>
            {
                var actions = new List<State>();
                var removes = new List<Rota>();

                for (var i = 0; i < _rotas.Count; i++)
                {
                    if (_rotas[i].Origem.Equals(state.Name))
                    {
                        actions.Add(new State(_rotas[i].Destino, state, _rotas[i].Custo + state.Cost));//crio um action pois a rota sera eliminada da lista de rotas ... e nao pode sumir da lista de actions
                        _rotas.RemoveAt(i);
                        i--;
                    } else if (_rotas[i].Destino.Equals(state.Name))
                    {
                        actions.Add(new State(_rotas[i].Origem, state, _rotas[i].Custo + state.Cost));
                        _rotas.RemoveAt(i);
                        i--;
                    }
                }

                

                return actions;
            };
            Func<IList<State>, State> getStateWithLowestCostFromFrontiers = (fs) =>
            {
                var cost = decimal.MaxValue;
                State state = null;

                for (var i = 0; i < fs.Count; i++)
                {
                    if (fs[i].Cost < cost)
                    {
                        state = fs[i];
                        cost = state.Cost;
                    }
                }
                return state;
            };
            Action<State, IList<State>> report = (s, f) =>
            {
                Console.Write("{0}({1}) => [ ", s.Name, s.Cost);
                foreach (var state in f)
                {
                    Console.Write("{0}({1}) ", state.Name, state.Cost);
                }
                Console.Write(" ]");
                Console.WriteLine("");
            };

            var costToTheGoal = decimal.MaxValue;
            while (frontiers.Count > 0)
            {
                removeStatesFromFrontierWithCostBiggerThanGoal(frontiers, costToTheGoal);
                var stateToExpand = getStateWithLowestCostFromFrontiers(frontiers);//get lowest cost state
                if (!stateToExpand.Name.Equals(goal))
                {
                    addStateToExploredList(stateToExpand);
                    var nearByFrontiers = expandStateAndGetNewFrontiersNearBy(stateToExpand);
                    addToFrontiersList(nearByFrontiers);
                    costToTheGoal = verifyIfTheGoalIsInsideTheFrontierAndGetItsLowestCostVersion(goal, costToTheGoal,frontiers);
                    removeFromFrontiersList(stateToExpand);
                }
                else
                {
                    addToGoalsList(stateToExpand);
                    removeFromFrontiersList(stateToExpand);
                }
                report(stateToExpand, frontiers);
            }

            return getStateWithLowestCostFromFrontiers(paths);
        }

        public State ChiepestFirstSearch_Old(string start, string goal)
        {
            State initialState = new State(start, null, 0.0m);
            IList<State> paths = new List<State>();
            IList<State> exploreds = new List<State>();
            IList<State> frontiers = new List<State>();
            frontiers.Add(initialState);

            Action<State> addStateToExploredList = (state) => { exploreds.Add(state); };
            Action<IList<State>> addToFrontiersList = (list) => { foreach (var item in list) { frontiers.Add(item); } };
            Action<State> removeFromFrontiersList = (state) => { frontiers.Remove(state); };
            Action<State> addToPathsList = (state) => { paths.Add(state); };
            Action<State, IList<State>> report = (s, f) =>
            {
                Console.Write("{0}({1}) => [ ", s.Name, s.Cost);
                foreach (var state in f)
                {
                    Console.Write("{0}({1}) ", state.Name, state.Cost);
                }
                Console.Write(" ]");
                Console.WriteLine("");
            };
            Action<IList<State>, decimal> RemoveStatesFromFrontierWithCostBiggerThanGoal = (listFrontiers, lowerCostToGoal) =>
            {
                var markToRemove = new List<State>();

                foreach (var frontier in listFrontiers)
                {
                    if (frontier.Cost > lowerCostToGoal)
                    {
                        markToRemove.Add(frontier);
                    }
                }

                //removendo as fronteiras marcadas
                foreach (var item in markToRemove)
                {
                    listFrontiers.Remove(item);
                }
            };
            Func<string, decimal, decimal> VerifyIfTheGoalIsInsideTheFrontierAndGetItsCost = (g, c) =>
            {
                foreach (var frontier in frontiers)
                {
                    if (frontier.Name.Equals(g))
                    {
                        if (c > frontier.Cost)
                            c = frontier.Cost;
                    }
                }
                return c;
            };
            


            var costToTheGoal = decimal.MaxValue;
            while (frontiers.Count > 0)
            {
                //RemoveStatesFromFrontierWithCostBiggerThanGoal(frontiers, costToTheGoal);

                var state = GetStateWithLowestCostFromFrontiers(frontiers);//get lowest cost state

                if (!state.Name.Equals(goal))
                {
                    addStateToExploredList(state);

                    var newFrontiers = ExpandStateAndGetNewFrontiersNearBy_(state);

                    addToFrontiersList(newFrontiers);

                    //costToTheGoal = VerifyIfTheGoalIsInsideTheFrontierAndGetItsCost(goal, costToTheGoal);

                    removeFromFrontiersList(state);
                }
                else
                {
                    addToPathsList(state);

                    removeFromFrontiersList(state);
                }

                report(state, frontiers);
            }

            var lowestPath = GetStateWithLowestCostFromFrontiers(paths);

            return lowestPath;
        }

        /// <summary>
        /// This method just copy the routes because methods just pass references of classes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paths"></param>
        /// <returns></returns>
        private IList<T> CopyFrom<T>(IList<T> paths)
        {
            var tempPaths = new List<T>();
            foreach (var path in paths)
            {
                tempPaths.Add(path);
            }
            return tempPaths;
        }

        /// <summary>
        /// This method finds the closest states names from routes and remove then, so cannot be counted twice
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private IList<State> ExpandStateAndGetNewFrontiersNearBy_(State state)
        {
            var actions = new List<State>();
            var removes = new List<Rota>();

            foreach (var rota in _rotas)
            {
                if (rota.Origem.Equals(state.Name))
                {
                    //actions.Add(rota.Destino);
                    actions.Add(new State(rota.Destino, state, rota.Custo + state.Cost));
                    removes.Add(rota);
                }
                if (rota.Destino.Equals(state.Name))
                {
                    //actions.Add(rota.Origem);
                    actions.Add(new State(rota.Origem, state, rota.Custo + state.Cost));
                    removes.Add(rota);
                }
            }

            foreach (var item in removes)
            {
                _rotas.Remove(item);
            }

            return actions;
        }

        /// <summary>
        /// This method select the state with the lowest to cost to explore
        /// </summary>
        /// <param name="frontiers">List of frontiers available</param>
        /// <returns></returns>
        private State GetStateWithLowestCostFromFrontiers(IList<State> frontiers)
        {
            var cost = decimal.MaxValue;
            State state = null;

            foreach (var item in frontiers)
            {
                if (item.Cost < cost)
                {
                    state = item;
                    cost = item.Cost;
                }
            }

            return state;
        }
    }
}

/*
Antes(17 rotas investigadas)
----------------------------
Arad(0,0) => [ Zerind(75,0) Sibiu(140,0) Timisoara(118,0)  ]
Zerind(75,0) => [ Sibiu(140,0) Timisoara(118,0) Oradea(146,0)  ]
Timisoara(118,0) => [ Sibiu(140,0) Oradea(146,0) Lugoj(229,0)  ]
Sibiu(140,0) => [ Oradea(146,0) Lugoj(229,0) Oradea(291,0) Rimnicu Vilcea(220,0) Fagaras(239,0)  ]
Oradea(146,0) => [ Lugoj(229,0) Oradea(291,0) Rimnicu Vilcea(220,0) Fagaras(239,0)  ]
Rimnicu Vilcea(220,0) => [ Lugoj(229,0) Oradea(291,0) Fagaras(239,0) Craiova(366,0) Pitesti(317,0)  ]
Lugoj(229,0) => [ Oradea(291,0) Fagaras(239,0) Craiova(366,0) Pitesti(317,0) Mehadia(299,0)  ]
Fagaras(239,0) => [ Oradea(291,0) Craiova(366,0) Pitesti(317,0) Mehadia(299,0) Bucharest(450,0)  ]
Oradea(291,0) => [ Craiova(366,0) Pitesti(317,0) Mehadia(299,0) Bucharest(450,0)  ]
Mehadia(299,0) => [ Craiova(366,0) Pitesti(317,0) Bucharest(450,0) Drobeta(374,0)  ]
Pitesti(317,0) => [ Craiova(366,0) Bucharest(450,0) Drobeta(374,0) Bucharest(418,0) Craiova(455,0)  ]
Craiova(366,0) => [ Bucharest(450,0) Drobeta(374,0) Bucharest(418,0) Craiova(455,0) Drobeta(486,0)  ]
Drobeta(374,0) => [ Bucharest(450,0) Bucharest(418,0) Craiova(455,0) Drobeta(486,0)  ]
Bucharest(418,0) => [ Bucharest(450,0) Craiova(455,0) Drobeta(486,0)  ]
Bucharest(450,0) => [ Craiova(455,0) Drobeta(486,0)  ]
Craiova(455,0) => [ Drobeta(486,0)  ]
Drobeta(486,0) => [  ]

Depois(14 rotas investigadas)
-----------------------------
Arad(0,0) => [ Zerind(75,0) Sibiu(140,0) Timisoara(118,0)  ]
Zerind(75,0) => [ Sibiu(140,0) Timisoara(118,0) Oradea(146,0)  ]
Timisoara(118,0) => [ Sibiu(140,0) Oradea(146,0) Lugoj(229,0)  ]
Sibiu(140,0) => [ Oradea(146,0) Lugoj(229,0) Oradea(291,0) Rimnicu Vilcea(220,0) Fagaras(239,0)  ]
Oradea(146,0) => [ Lugoj(229,0) Oradea(291,0) Rimnicu Vilcea(220,0) Fagaras(239,0)  ]
Rimnicu Vilcea(220,0) => [ Lugoj(229,0) Oradea(291,0) Fagaras(239,0) Craiova(366,0) Pitesti(317,0)  ]
Lugoj(229,0) => [ Oradea(291,0) Fagaras(239,0) Craiova(366,0) Pitesti(317,0) Mehadia(299,0)  ]
Fagaras(239,0) => [ Oradea(291,0) Craiova(366,0) Pitesti(317,0) Mehadia(299,0) Bucharest(450,0)  ]
Oradea(291,0) => [ Craiova(366,0) Pitesti(317,0) Mehadia(299,0) Bucharest(450,0)  ]
Mehadia(299,0) => [ Craiova(366,0) Pitesti(317,0) Bucharest(450,0) Drobeta(374,0)  ]
Pitesti(317,0) => [ Craiova(366,0) Bucharest(450,0) Drobeta(374,0) Bucharest(418,0) Craiova(455,0)  ]
Craiova(366,0) => [ Drobeta(374,0) Bucharest(418,0) Drobeta(486,0)  ]
Drobeta(374,0) => [ Bucharest(418,0)  ]
Bucharest(418,0) => [  ]

*/
