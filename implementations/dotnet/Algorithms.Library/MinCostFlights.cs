using System.Collections.Generic;
using System;
using System.Linq;
public class MinCostFlights
{
    class Pair
    {
        public int destination;
        public int cost;
        public Pair(int destination, int cost)
        {
            this.destination = destination;
            this.cost = cost;
        }
    }
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {


        Dictionary<int, List<int[]>> graph = new Dictionary<int, List<int[]>>();
        foreach (int[] flight in flights)
        {
            if (!graph.ContainsKey(flight[0]))
                graph.Add(flight[0], new List<int[]>() { new int[] { flight[1], flight[2] } });
            else
                graph[flight[0]].Add(new int[] { flight[1], flight[2] });
        }

        int[] distances = new int[n];
        Array.Fill(distances, int.MaxValue);

        distances[src] = 0;
        Queue<DataTravel> queue = new();
        queue.Enqueue(new DataTravel(0, src, 0));

        while (queue.Count != 0)
        {

            var data = queue.Dequeue();
            int stop = data.k;
            int node = data.source;
            int cost = data.cost;

            if (stop > k) continue;
            if (!graph.ContainsKey(node)) continue;
            foreach (int[] toCity in graph[node])
            {
                if (cost + toCity[1] > distances[toCity[0]])
                    continue;
                distances[toCity[0]] = cost + toCity[1];
                queue.Enqueue(new DataTravel(stop + 1, toCity[0], cost + toCity[1]));
            }



        }

        return distances[dst] == Int32.MaxValue ? -1 : distances[dst];


    }
}

public class DataTravel
{
    public int k;
    public int source;
    public int cost;

    public DataTravel(int k, int source, int cost)
    {
        this.k = k;
        this.source = source;
        this.cost = cost;
    }
}