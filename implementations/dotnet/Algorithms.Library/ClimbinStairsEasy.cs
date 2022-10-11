using System;
using System.Collections.Generic;
namespace Algorithms.Library
{


    public class ClimbinStairsEasy
    {
        public int MinCostClimbingStairsIterative(int[] cost) 
        {
           int[]gains= new int[cost.Length+1];
            gains[0]=cost[0];
            gains[1]=cost[1];

            for(int i=2;i<cost.Length+1;i++)
            {
                int current = i==cost.Length?0:cost[i];
                gains[i]=current+Math.Min(gains[i-1],gains[i-2]);
            }

            return gains[gains.Length-1];
        }
        public int MinCostClimbingStairs(int[] cost)
        {
            Dictionary<int, int> indexSol = new();
            return CostCalc(cost, cost.Length, indexSol);

        }
        public int CostCalc(int[] cost, int n, Dictionary<int, int> indexSol)
        {
            if (n == 1) return cost[1];
            if (n == 0) return cost[0];


            if (indexSol.ContainsKey(n))
                return indexSol[n];

            int currentCost = n == cost.Length ? 0 : cost[n];

            indexSol.Add(n, Math.Min(CostCalc(cost, n - 1, indexSol), CostCalc(cost, n - 2, indexSol)) + currentCost);
            return indexSol[n];
        }
    }
}
