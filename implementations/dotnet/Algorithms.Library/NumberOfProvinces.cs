using System.Collections.Generic;
using System;
public class NumberOfProvinces
{
    HashSet<int> globalVisited = new();
    Dictionary<int, HashSet<int>> adjList = new();

    public int FindCircleNum(int[][] isConnected)
    {

        for (int i = 0; i < isConnected.Length; i++)
        {
            for (int j = 0; j < isConnected[i].Length; j++)
            {
                if (!adjList.ContainsKey(i)) adjList.Add(i, new HashSet<int>());
                if (!adjList.ContainsKey(j)) adjList.Add(j, new HashSet<int>());

                if (i != j && isConnected[i][j] != 0)
                {

                    adjList[i].Add(j);
                    adjList[j].Add(i);
                }
            }

        }

        int provinces = 0;

        foreach (var source in adjList.Keys)
        {
            if (globalVisited.Contains(source)) continue;
            globalVisited.Add(source);
            if (BFS(source) != 0)
                provinces++;
        }

        return provinces;

    }
    private int BFS(int source)
    {
        if (adjList[source].Count == 0) return 1;

        Queue<int> queue = new();
        int len = 0;
        queue.Enqueue(source);

        while (queue.Count != 0)
        {
            int parent = queue.Dequeue();
            len++;

            foreach (var neig in adjList[parent])
            {
                if (globalVisited.Contains(neig)) continue;

                globalVisited.Add(neig);
                queue.Enqueue(neig);
            }

        }

        return len;
    }
}
