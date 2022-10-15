using System.Collections.Generic;

namespace Algorithms.Library
{
    public class ReachableNodesWithRestrictions
    {

        Dictionary<int, HashSet<int>> adjList = new();
        HashSet<int> visted = new();
        HashSet<int> restrictedHS = new();



        public int ReachableNodes(int n, int[][] edges, int[] restricted)
        {

            int i;
            for (i = 0; i < n; i++)
                adjList.Add(i, new HashSet<int>());

            for (i = 0; i < edges.Length; i++)
            {
                adjList[edges[i][0]].Add(edges[i][1]);
                adjList[edges[i][1]].Add(edges[i][0]);

            }
            for (i = 0; i < restricted.Length; i++)
                restrictedHS.Add(restricted[i]);
            visted.Add(0);
            return CountDFS(source: 0) + 1;


        }

        public int CountDFS(int source)
        {
            if (adjList[source].Count == 0) return 0;

            int aux = 0;

            foreach (var children in adjList[source])
            {
                if (restrictedHS.Contains(children) || visted.Contains(children))
                    continue;
                else
                {
                    visted.Add(children);
                    aux += CountDFS(children) + 1;
                }
            }
            return aux;
        }

    }
}