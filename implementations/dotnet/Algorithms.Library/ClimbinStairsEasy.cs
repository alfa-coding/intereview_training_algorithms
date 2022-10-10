using System;
using System.Collections.Generic;
namespace Algorithms.Library
{


    public class ClimbinStairsEasy
    {
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