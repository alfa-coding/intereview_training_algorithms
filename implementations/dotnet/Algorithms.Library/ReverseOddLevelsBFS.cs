using System.Collections.Generic;

namespace Algorithms.Library
{

    public class ReverseOddLevelsBFS
    {


        public TreeNode ReverseOddLevels(TreeNode root)
        {

            GoReverse(root, parity: 0);
            return root;

        }

        public void GoReverse(TreeNode current, int parity)
        {
            List<TreeNode> queue = new();
            queue.Add(current);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                if (parity % 2 == 1)
                {
                    for (int i = 0; i <size/2; i++)
                    {

                        var tmpval = queue[i].val;
                        queue[i].val = queue[size - 1 - i].val;
                        queue[size - 1 - i].val = tmpval;

                    }
                }

                for (int i = 0; i < size; i++)
                {
                    var tmpNode = queue[0];
                    if (tmpNode.left != null)
                        queue.Add(tmpNode.left);

                    if (tmpNode.right != null)
                        queue.Add(tmpNode.right);

                    queue.RemoveAt(0);
                }
                parity++;
            }
        }
    }
}