using System.Collections.Generic;
using System;
public class TimeToInform
{
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {

        Dictionary<int, HashSet<int>> adjancencyList = new();

        for (int i = 0; i < n; i++)
            if (!adjancencyList.ContainsKey(i)) adjancencyList.Add(i, new HashSet<int>());

        for (int i = 0; i < n; i++)
        {
            if (manager[i] == -1) continue;
            adjancencyList[manager[i]].Add(i);
        }

        return DFS(informTime, headID, adjancencyList);

    }

    public int DFS(int[] informTime, int source, Dictionary<int, HashSet<int>> adjacencyList)
    {
        if (adjacencyList[source] == null || adjacencyList[source].Count == 0)
            return 0;
        else
        {
            int maxLevel = int.MinValue;
            foreach (var children in adjacencyList[source])
            {
                maxLevel = Math.Max(maxLevel, DFS(informTime, children, adjacencyList));
            }
            return informTime[source] + maxLevel;
        }
    }
}