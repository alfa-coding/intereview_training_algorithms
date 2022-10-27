using System.Collections.Generic;

namespace Algorithms.Library
{
    public class MinDepthEx
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            int response = 0;

            while (queue.Count != 0)
            {
                response++;
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    var tmp = queue.Dequeue();
                    if (tmp.right == null && tmp.left == null) return response;
                    if (tmp.left != null)
                        queue.Enqueue(tmp.left);
                    if (tmp.right != null)
                        queue.Enqueue(tmp.right);
                }
            }

            return response;

        }
    }
}