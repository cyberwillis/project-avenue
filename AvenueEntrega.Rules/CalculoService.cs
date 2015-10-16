﻿using System;
using System.Collections.Generic;
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

            Action<State> addToExploredList = (state) => { exploreds.Add(state); };
            Action<IList<State>> addToFrontiersList = (list) => { foreach (var item in list) { frontiers.Add(item); } };
            Action<State> removeFromFrontiersList = (state) => { frontiers.Remove(state); };
            Action<State> addToPathsList = (state) => { paths.Add(state); };

            while (frontiers.Count > 0)
            {
                //get lowest cost state
                var state = GetStateWithLowestCost(frontiers);

                if (!state.Name.Equals(goal))
                {
                    addToExploredList(state);

                    //find frontiers for it
                    var newFrontiers = GetFrontiersFrom(state);
                    addToFrontiersList(newFrontiers);

                    removeFromFrontiersList(state);
                }
                else
                {
                    addToPathsList(state);

                    removeFromFrontiersList(state);
                    //Console.WriteLine(state.Cost);
                }
            }

            var lowestPath = GetStateWithLowestCost(paths);

            /*var testePath = finalPath.GetPath();
            foreach (var p in testePath)
            {
                Console.WriteLine(p);
            }*/

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
        private IList<State> GetFrontiersFrom(State state)
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
        private State GetStateWithLowestCost(IList<State> frontiers)
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
