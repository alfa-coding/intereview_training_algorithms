using System.Collections.Generic;
using System;

namespace Algorithms.Library
{
    public class BipartiteGraph
    {
        public bool IsBipartite(int[][] graph)
        {

            int[] colors = new int[graph.Length];

            Array.Fill(colors, -1);
            for (int i = 0; i < graph.Length; i++)
            {

                if (colors[i] == -1)
                {
                    colors[i] = 1;
                    if (!BFS(i, colors, graph))
                        return false;
                }

            }

            return true;
        }

        private bool BFS(int source, int[] colors, int[][] graph)
        {

            Queue<int> queue = new();
            queue.Enqueue(source); //enqueueing the source

            while (queue.Count != 0)
            {
                int uSource = queue.Dequeue();



                foreach (var vecino in graph[uSource])
                {
                    if (colors[vecino] == -1)
                    {
                        //coloreo con el color opuesto al mio;
                        colors[vecino] = 1 - colors[uSource];
                        queue.Enqueue(vecino);
                    }
                    else if (colors[vecino] == colors[uSource])
                        return false; // hay arista, pero el vecino esta coloreado como yo
                    else
                        continue;



                }
            }

            return true;

        }
    }
}