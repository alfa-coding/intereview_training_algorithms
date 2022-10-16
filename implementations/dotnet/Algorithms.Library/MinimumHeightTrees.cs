using System.Collections.Generic;
using System.Linq;
using System;

namespace Algorithms.Library
{
    public class CalMinimumHeightTrees
    {
        SortedDictionary<int, int> hs = new();

        private int Heigth(Dictionary<int, HashSet<int>> adjList, int source, HashSet<int> visited)
        {
            if (adjList[source].Count == 0) return 1;
            if (adjList[source].Count == 1 && visited.Contains(adjList[source].First())) return 1;

            //if(hs.ContainsKey(source))return hs[source];

            int maxHeight = int.MinValue;
            foreach (var neig in adjList[source])
            {
                if (visited.Contains(neig)) continue;

                visited.Add(neig);
                int currentHeight = Heigth(adjList, neig, visited);
                maxHeight = Math.Max(currentHeight, maxHeight);

            }

            return 1 + maxHeight;
        }
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {

            Dictionary<int, HashSet<int>> adjList = new();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(i, new HashSet<int>());
            }
            for (int i = 0; i < edges.Length; i++)
            {
                adjList[edges[i][0]].Add(edges[i][1]);
                adjList[edges[i][1]].Add(edges[i][0]);

            }

            //once the graph is constructed, I want to calculate the height
            //of every posible root and save the result in a height array
            HashSet<int> visited;

            List<int> response = new List<int>(n);

            for (int i = 0; i < n; i++)
            {
                visited = new();
                visited.Add(i);
                int hFromI = Heigth(adjList, i, visited);
                hs.Add(i, hFromI);

                if (response.Count == 0 || hs[response.Last()] == hFromI)
                {
                    response.Add(i); continue;
                }
                if (response.Count == 0 || hFromI < hs[response.Last()])
                {
                    response.Clear();
                    response.Add(i);
                }


            }

            return response;
        }
    }
}