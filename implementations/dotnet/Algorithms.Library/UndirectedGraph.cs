using System;
using System.Collections.Generic;
namespace Algorithms.Library
{
    public class UndirectedGraph<T>
    {
        public bool HasCycles { get; set; }
        public UndirectedGraph(List<Tuple<T, T>> edges,bool hasCycles)
        {
            this.HasCycles = hasCycles;
            ConvertToAdjacencyList(edges);
        }

        private void ConvertToAdjacencyList(List<Tuple<T, T>> edges)
        {
            this.AdjacencyList = new Dictionary<T, List<T>>();
            foreach (var connection in edges)
            {
                if (!this.AdjacencyList.ContainsKey(connection.Item1))
                {
                    this.AdjacencyList.Add(connection.Item1, new List<T>());
                }
                if (!this.AdjacencyList.ContainsKey(connection.Item2))
                {
                    this.AdjacencyList.Add(connection.Item2, new List<T>());
                }
                this.AdjacencyList[connection.Item1].Add(connection.Item2);
                this.AdjacencyList[connection.Item2].Add(connection.Item1);

            }
        }

        public Dictionary<T, List<T>> AdjacencyList { get; set; }
    }
}
