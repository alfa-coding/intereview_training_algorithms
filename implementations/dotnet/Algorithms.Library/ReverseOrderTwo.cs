using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Library
{
    public class ReverseOrderTwo
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> response = new List<IList<int>>();

            if (root == null) return response;

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            List<int> level;
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
                response.Add(level);
            }


            response.Reverse();
            return response;
        }
    }
}