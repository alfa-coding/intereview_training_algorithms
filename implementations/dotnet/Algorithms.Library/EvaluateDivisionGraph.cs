using System.Collections.Generic;
using System;

namespace Algorithms.Library
{
    public class EvaluateDivisionGraph
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {

            Dictionary<string, Dictionary<string, double>> map = new();

            for (int i = 0; i < values.Length; i++)
            {
                var equation = equations[i];
                string dividend = equation[0];
                string divisor = equation[1];
                double quotient = values[i];
                if (!map.ContainsKey(dividend))
                {
                    map.Add(dividend, new Dictionary<string, double>());
                }
                if (!map.ContainsKey(divisor))
                {
                    map.Add(divisor, new Dictionary<string, double>());
                }
                map[dividend].Add(divisor, quotient);
                map[divisor].Add(dividend, 1 / quotient);
            }
            double[] res = new double[queries.Count];
            for (int i = 0; i < res.Length; i++)
            {
                var query = queries[i];
                if (!map.ContainsKey(query[0]) || !map.ContainsKey(query[1]))
                {
                    res[i] = -1;
                }
                else
                {
                    res[i] = dfs(map, query[0], query[1], 1.0, new HashSet<string>());
                }
            }
            return res;
        }
        private double dfs(Dictionary<string, Dictionary<string, double>> map, string start, string target, double r, HashSet<string> seen)
        {

            if (start.Equals(target))
            {
                return r;
            }
            Dictionary<string, Double> m = map[start];
            foreach (var s in m.Keys)
            {
                if (seen.Contains(s))
                {
                    continue;
                }
                seen.Add(s);
                double res = dfs(map, s, target, r * m[s], seen);
                if (res != -1)
                {
                    return res;
                }
                seen.Remove(s);
            }
            return -1;
        }
    }
}