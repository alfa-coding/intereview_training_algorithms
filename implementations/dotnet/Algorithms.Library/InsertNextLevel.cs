using System.Collections.Generic;

namespace Algorithms.Library
{
    public class InsertNextLevel
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {

            {
                if (depth == 1)
                {
                    TreeNode answer = new TreeNode(val, root);
                    return answer;
                }

                TreeNode rootCopy = root;

                Queue<TreeNode> queue = new();
                List<TreeNode> previous = new();
                List<TreeNode> next = new();



                queue.Enqueue(rootCopy);
                int level = 0;

                while (level != depth || queue.Count != 0)
                {
                    next = new List<TreeNode>(previous);
                    previous = new();


                    level++;
                    if (level == depth) break;

                    int size = queue.Count;

                    for (int i = 0; i < size; i++)
                    {
                        var tmp = queue.Dequeue();
                        previous.Add(tmp);

                        if (tmp.left != null)
                        {
                            queue.Enqueue(tmp.left);

                        }
                        if (tmp.right != null)
                        {
                            queue.Enqueue(tmp.right);

                        }
                    }
                }

                foreach (var node in next)
                {


                    TreeNode left = node.left;
                    TreeNode right = node.right;

                    if (left == null)
                    {
                        node.left = new TreeNode(val);
                    }
                    else
                    {
                        node.left = new TreeNode(val, left);
                    }

                    if (right == null)
                    {
                        node.right = new TreeNode(val);
                    }
                    else
                    {
                        node.right = new TreeNode(val, null, right);
                    }
                }



                return root;

            }

        }
    }

}