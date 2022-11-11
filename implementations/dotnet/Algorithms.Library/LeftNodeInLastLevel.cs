using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Library
{


    public class LeftNodeInLastLevel
    {


        public int FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            List<int> level = new();
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

            }
            return level.First();
        }
    }
}