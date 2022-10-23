using System;
using System.Collections.Generic;
namespace Algorithms.Library
{

    public class LCA
    {
        Dictionary<int, TreeNode> valPos = new();
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            List<int[]> nodesAndHeig = new List<int[]>();

            FillByTraversing(root, nodesAndHeig, 0);
            int i = 0;
            foreach (var item in nodesAndHeig)
            {
                System.Console.WriteLine($"i={i},n:{item[0]},h={item[1]}");
                i++;
            }
            int p1 = 0;
            int postP = -1;
            int postQ = -1;

            int menorTmp = int.MaxValue;
            int menor = -1;
            while (p1 < nodesAndHeig.Count && postQ == -1)
            {
                if (nodesAndHeig[p1][0] == q.val && postP != -1)
                {
                    postQ = p1;
                }
                if (nodesAndHeig[p1][0] == p.val && postQ == -1)
                {
                    postP = p1;
                }
                p1++;

            }
            if (postP == -1 || postQ == -1)
            {
                p1 = 0;
                postP = -1;
                postQ = -1;

                menorTmp = int.MaxValue;
                menor = -1;

                while (p1 < nodesAndHeig.Count && postQ == -1)
                {
                    if (nodesAndHeig[p1][0] == p.val && postP != -1)
                    {
                        postQ = p1;
                    }
                    if (nodesAndHeig[p1][0] == q.val && postQ == -1)
                    {
                        postP = p1;
                    }
                    p1++;

                }
            }
            for (i = postP; i <= postQ; i++)
            {
                if (nodesAndHeig[i][1] < menorTmp)
                {
                    menorTmp = nodesAndHeig[i][1];
                    menor = nodesAndHeig[i][0];
                }
            }

            return valPos[menor];
        }

        private void FillByTraversing(TreeNode current, List<int[]> nodesAndHeig, int h)
        {
            if (current == null) return;

            if (!this.valPos.ContainsKey(current.val))
                this.valPos.Add(current.val, current);

            nodesAndHeig.Add(new int[] { current.val, h });

            if (current.left == null && current.right == null) return;

            FillByTraversing(current.left, nodesAndHeig, h + 1);

            nodesAndHeig.Add(new int[] { current.val, h });

            FillByTraversing(current.right, nodesAndHeig, h + 1);

            nodesAndHeig.Add(new int[] { current.val, h });
        }
    }
}