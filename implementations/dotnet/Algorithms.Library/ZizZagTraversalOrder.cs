using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class ZizZagTraversalOrder
    {


        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> response = new List<IList<int>>();

            if (root == null) return response;

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            List<int> level;

            bool rightToLeft = true;
            while (queue.Count != 0)
            {
                level = new();
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var tmpNode = queue.Dequeue();
                    level.Add(tmpNode.val);
                    if (tmpNode.left != null)
                        queue.Enqueue(tmpNode.left);

                    if (tmpNode.right != null)
                        queue.Enqueue(tmpNode.right);
                }
                if (rightToLeft)
                    response.Add(level);
                else
                {
                    level.Reverse();
                    response.Add(level);
                }
                rightToLeft = !rightToLeft;
            }

            return response;

        }
    }
}