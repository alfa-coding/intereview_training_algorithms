using System.Collections.Generic;
using System;
using System.Linq;

namespace Algorithms.Library
{

    public class NetworkDelay
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {

            int[] distances = Enumerable.Range(0, n).Select(_ => int.MaxValue).ToArray();
            Dictionary<int, List<Pair>> adjList = new();
            distances[k - 1] = 0;

            var heap = new PriorityQueue<int, int>();

            heap.Enqueue(k - 1, distances[k - 1]);

            for(int i=0;i<n;i++)
                adjList.Add(i,new List<Pair>());

            for (int i = 0; i < times.Length; i++)
            {
                int source = times[i][0];
                int target = times[i][1];
                int weight = times[i][2];
                adjList[source - 1].Add(new Pair(targetNode: target - 1, weight: weight));
            }

            while (heap.Count != 0)
            {
                int currentVertex = heap.Dequeue();

                var adjacent = adjList[currentVertex];
                for (int i = 0; i < adjacent.Count; i++)
                {
                    int neighboringVertex = adjacent[i].TargetNode;
                    int weight = adjacent[i].Weight;
                    if (distances[currentVertex] + weight < distances[neighboringVertex])
                    {
                        distances[neighboringVertex] = distances[currentVertex] + weight;
                        heap.Enqueue(neighboringVertex, distances[neighboringVertex]);
                    }


                }


            }
            int ans = distances.Max();

            return ans == int.MaxValue ? -1 : ans;

        }
    }
    public class Pair
    {
        public int Weight { get; set; }
        public int TargetNode { get; set; }
        public Pair(int weight, int targetNode)
        {
            Weight = weight;
            TargetNode = targetNode;
        }
    }
}