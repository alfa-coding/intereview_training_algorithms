using System.Collections.Generic;

namespace Algorithms.Library
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left=null, Node _right=null, Node _next=null)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    public class NodesToTheRight
    {
        public Node Connect(Node root)
        {
            if (root is null) return null;

            Queue<Node> queue = new();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                List<Node> level = new();

                for (int i = 0; i < size; i++)
                {
                    Node tmp = queue.Dequeue();
                    level.Add(tmp);
                    if (tmp.left is not null)
                        queue.Enqueue(tmp.left);
                    if (tmp.right is not null)
                        queue.Enqueue(tmp.right);
                }

                if (level.Count > 0)
                {
                    for (int i = level.Count - 1; i > 0; i--)
                    {
                        level[i - 1].next = level[i];
                    }
                }

            }

            return root;

        }
    }
}