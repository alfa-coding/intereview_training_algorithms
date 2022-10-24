using System.Collections.Generic;
using System;

namespace Algorithms.Library
{
    public class BipartiteGraph
    {
        public bool IsBipartite(int[][] graph)
        {

            int[] colors = new int[graph.Length];
            int [,]matrix = new int[graph.Length,graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    matrix[i,graph[i][j]] =1;
                    matrix[graph[i][j],i] =1;

                }
            }
            Array.Fill(colors, -1);
            for (int i = 0; i < graph.Length; i++)
            {

                if (colors[i] == -1)
                {
                    colors[i] = 1;
                    if (!BFS(i, colors, matrix))
                        return false;
                }

            }

            return true;
        }

        private bool BFS(int source, int[] colors, int[,] graph)
        {

            Queue<int> queue = new();
            queue.Enqueue(source); //enqueueing the source

            while (queue.Count != 0)
            {
                int uSource = queue.Dequeue();



                for (int vecino = 0; vecino < graph.GetLength(0); vecino++)
                {
                    if (graph[uSource,vecino] == 1)
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
            }

            return true;

        }
    }
}