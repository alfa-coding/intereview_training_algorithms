using System;
using System.Collections.Generic;


namespace Algorithms.Library
{
    public class PathMininumEfforDij
    {
        public int MinimumEffortPath(int[][] heights)
        {  //            e, s, w, n
            int[] dirC = { 1, 0, -1, 0 };
            int[] dirF = { 0, 1, 0, -1 };

            int m = heights.Length;
            int n = heights[0].Length;
            var esfuerzo = new List<int[]>(m);

            for (int i = 0; i < m; i++)
            {
                esfuerzo.Add(new int[n]);

                Array.Fill(esfuerzo[i], int.MaxValue);
            }
            int[][] efforts = esfuerzo.ToArray();

            efforts[0][0] = 0;
            PriorityQueue<int[], int> pq = new();
            pq.Enqueue(new int[2], 0);
            while (pq.Count != 0)
            {
                int[] cur = pq.Dequeue();

                int x = cur[0], y = cur[1];
                int effort = efforts[x][y];
                if (x == m - 1 && y == n - 1)
                {
                    return effort;
                }
                for (int k = 0; k < 4; ++k)
                {
                    int r = x + dirF[k], c = y + dirC[k];

                    if (0 <= r && r < m && 0 <= c && c < n)
                    {
                        int nextEffort = Math.Max(effort, Math.Abs(heights[r][c] - heights[x][y]));
                        if (efforts[r][c] > nextEffort)
                        {
                            efforts[r][c] = nextEffort;
                            pq.Enqueue(new int[] { r, c }, nextEffort);
                        }
                    }
                }
            }
            return -1;

        }
    }
}