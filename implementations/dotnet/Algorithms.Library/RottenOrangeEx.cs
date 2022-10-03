using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{


    public class RottenOranges
    {
        class Pair
        {
            public int f;
            public int c;
            public Pair(int f, int c)
            {
                this.f = f;
                this.c = c;
            }
        }

        public int[] dirf = { 0, 1, 0, -1 };
        public int[] dirc = { 1, 0, -1, 0 };
        public int m;
        public int n;
        public int[,] steps;

        public bool InRange(int f, int c)
        {
            return f >= 0 && f < m && c >= 0 && c < n;
        }
        public int OrangesRotting(int[][] grid)
        {
            this.m = grid.Length;
            this.n = grid[0].Length;
            this.steps = new int[m, n];


            int freshes = 0;
            Queue<Pair> initialRotten = new();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    { steps[i, j] = -1; freshes += 1; }


                    if (grid[i][j] == 2)
                    {
                        var init = new Pair(i, j);

                        initialRotten.Enqueue(init);
                        steps[i, j] = 0;

                    }
                }
            }

            if (initialRotten.Count == 0)
            {
                if (freshes != 0)
                    return -1;
                return 0;
            }

            while (initialRotten.Count != 0)
            {
                //bfs
                var tmp = initialRotten.Dequeue();
                //System.Console.WriteLine($"f:{tmp.f},c:{tmp.c},v={steps[tmp.f,tmp.c]}");
                for (int i = 0; i < 4; i++)
                {
                    //e s w n
                    int nf = tmp.f + dirf[i];
                    int nc = tmp.c + dirc[i];

                    if (InRange(nf, nc) && steps[nf, nc] == -1 && grid[nf][nc] == 1)
                    {
                        steps[nf, nc] = steps[tmp.f, tmp.c] + 1;
                        initialRotten.Enqueue(new Pair(nf, nc));
                    }
                }
            }


            int maxTmp = int.MinValue;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1 && steps[i, j] == -1)
                        return -1;
                    if (grid[i][j] != 0 && steps[i, j] != -1)
                        maxTmp = Math.Max(maxTmp, steps[i, j]);
                }
            }
            return maxTmp;



        }
    }
}