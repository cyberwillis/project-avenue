using System.Collections.Generic;

namespace AvenueEntrega.Rules
{
    public class State
    {
        public string Name { get; }
        public decimal Cost { get; }
        public State Parent { get; }
        public State(string name, State parent, decimal cost)
        {
            Name = name;
            Parent = parent;
            Cost = cost;
        }

        /// <summary>
        /// This method trace back the path recursively by the parents
        /// </summary>
        /// <returns></returns>
        public IList<string> GetPath()
        {
            var path = new List<string>();

            if (Parent != null)
                path.AddRange(Parent.GetPath());

            path.Add(Name);

            return path;
        }

        //public float GetTotalCost()
        //{
        //    float TotalCost = 0f;

        //    if (Parent != null)
        //        TotalCost += Parent.GetTotalCost();

        //    TotalCost += Cost;

        //    return TotalCost;
        //}
    }
}